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
        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }

        stage('clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master',
                url: 'https://github.com/pwujczyk/ProductivityTools.Meetings'
            }
        }
        stage('build') {
            steps {
                bat(script: "dotnet publish ProductivityTools.Meetings.sln -c Release ", returnStdout: true)
            }
        }
        stage('deleteDbMigratorDir') {
            steps {
                bat('if exist "C:\\Bin\\MeetingsDdbMigration" RMDIR /Q/S "C:\\Bin\\MeetingsDdbMigration"')
            }
        }
        stage('copyDbMigratorFiles') {
            steps {
                bat('xcopy "C:\\Program Files (x86)\\Jenkins\\workspace\\Meetings\\src\\Server\\ProductivityTools.Meetings.DatabaseMigrations\\bin\\Release\\netcoreapp3.1\\publish" "C:\\Bin\\MeetingsDdbMigration\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\MeetingsDdbMigration\\ProductivityTools.Meetings.DatabaseMigrations.exe')
            }
        }

        stage('stopMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:meetings')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\Meetings" RMDIR /Q/S "C:\\Bin\\Meetings"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "C:\\Program Files (x86)\\Jenkins\\workspace\\Meetings\\src\\Server\\ProductivityTools.Meetings.WebApi\\bin\\Release\\netcoreapp3.1\\publish" "C:\\Bin\\Meetings\\" /O /X /E /H /K')
				                      
            }
        }

        stage('startMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:meetings')
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
