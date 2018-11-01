pipeline {
  agent {
    docker {
      label 'docker'
      image 'microsoft/dotnet'
    }
  }

  stages {
    stage('Build') {
      steps {
        sh 'git clean -fdx'
        sh 'dotnet msbuild -t:restore -p:RestoreSources="https://api.nuget.org/v3/index.json;https://api.bintray.com/nuget/fint/nuget" FINT.Model.Resource.Felles.sln'
        sh 'dotnet test FINT.Model.Resource.Felles.Tests'
        sh 'dotnet msbuild -t:build,pack -p:Configuration=Release FINT.Model.Resource.Felles.sln'
        stash includes: '**/Release/*.nupkg', name: 'libs'
      }
    }

    stage('Deploy') {
      environment {
        BINTRAY = credentials('fint-bintray')
      }
      when {
        branch 'master'
      }
      steps {
        unstash 'libs'
        archiveArtifacts '**/*.nupkg'
        sh "dotnet nuget push FINT.Model.Resource.Felles/bin/Release/FINT.Model.Resource.Felles.*.nupkg -k ${BINTRAY} -s https://api.bintray.com/nuget/fint/nuget"
      }
    }
  }
}
