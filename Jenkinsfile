properties([pipelineTriggers([githubPush()])])

pipeline {
    agent any

    stages {
        stage('hello') {
            steps {
                // Get some code from a GitHub repository
                echo 'hello'
            }
        }
		stage('workplacePath'){
			steps{
				echo "${env.WORKSPACE}"
			}
		}
        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }

        stage('clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master',
                url: 'https://github.com/ProductivityTools-TrainingLog/ProductivityTools.TrainingLog.Api'
            }
        }
        stage('build') {
            steps {
				echo 'starting bddduild'
                bat('dotnet publish ProductivityTools.TrainingLog.Api.sln -c Release')
            }
        }
        stage('deleteDbMigratorDir') {
            steps {
                bat('if exist "C:\\Bin\\TrainingLogDdbMigration" RMDIR /Q/S "C:\\Bin\\TrainingLogDdbMigration"')
            }
        }
        stage('copyDbMigratorFiles') {
            steps {
                bat('xcopy "ProductivityTools.TrainingLog.DbUp\\bin\\Release\\netcoreapp3.1\\publish\\" "C:\\Bin\\TrainingLogDdbMigration\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\TrainingLogDdbMigration\\ProductivityTools.TrainingLog.DbUp.exe')
            }
        }

        stage('stopMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:TrainingLog')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\TrainingLog" RMDIR /Q/S "C:\\Bin\\TrainingLog"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "Src\\Server\\ProductivityTools.GetTask3.API\\bin\\Release\\netcoreapp3.1\\publish\\" "C:\\Bin\\GetTask3\\" /O /X /E /H /K')				              
            }
        }

        stage('startMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:GetTask3')
            }
        }
        stage('byebye') {
            steps {
                // Get some code from a GitHub repository
                echo 'byebye'
            }
        }
    }
}
