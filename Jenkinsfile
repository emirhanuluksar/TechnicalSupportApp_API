pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Restore Packages') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }

        stage('Publish') {
            steps {
                script {
                    sh 'dotnet publish -c Release'
                    def publishDir = 'src/TSA.Presentation/TSA.Presentation.WebAPI/bin/Release/net8.0/publish'
                    echo "Publishing from: ${publishDir}"
                    sh "cp -r ${publishDir}/* /var/www/dhtechnic"
                }
            }
        }

        stage('Restart Project') {
            steps {
                script {
                    def publishDir = '/var/www/dhtechnic'
                    def isDirExists = fileExists(publishDir)
            
                    if (isDirExists) {
                        echo "Published files found. Restarting project..."
                        sh 'sudo systemctl restart dhtechnic.service'
                    } else {
                        error "Published files not found. Deployment aborted."
                    }
                }
            }
        }
    }
}
