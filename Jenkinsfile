pipeline {
  agent {
    docker {
      label 'docker'
      image 'microsoft/dotnet'
    }
  }
  stages {
    stage('Build') {
      environment {
        BINTRAY = credentials('fint-bintray')
      }
      when {
        branch 'master'
      }
      steps {
        retry(3) {
          sh 'git clean -fdx'
          sh 'dotnet restore'
        }
        sh 'dotnet test FINT.Model.Resource.Felles.Tests'
        sh 'dotnet build -c Release'
        sh 'dotnet pack -c Release'
        archiveArtifacts '**/*.nupkg'
        sh "dotnet nuget push FINT.Model.Resource.Felles/bin/Release/FINT.Model.Resource.Felles.*.nupkg -k ${BINTRAY} -s https://api.bintray.com/nuget/fint/nuget"
      }
    }
  }
}
