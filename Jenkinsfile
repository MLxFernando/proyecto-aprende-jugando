pipeline {
    agent any 

    environment {
        UNITY_VERSION = "2022.3.37f1"  // Versión de Unity usada
        UNITY_EXECUTABLE = "C:/Program Files/Unity/Hub/Editor/2022.3.37f1/Editor/Unity.exe"
        PROJECT_PATH = "C:/ProgramData/Jenkins/.jenkins/workspace/Proyecto-CI-CD"
        BUILD_PATH = "Builds/Android"
    }

    stages {
        stage('Clonar Código') {
            steps {
                git branch: 'main', url: 'https://github.com/MLxFernando/proyecto-aprende-jugando.git'
            }
        }

        stage('Compilar Juego') {
            steps {
                bat "${UNITY_EXECUTABLE} -batchmode -nographics -quit -projectPath ${PROJECT_PATH} -executeMethod BuildScript.PerformBuild -logFile build.log"
            }
        }

        stage('Generar APK') {
            steps {
                bat """
                ${UNITY_EXECUTABLE} -batchmode -nographics -quit -projectPath ${PROJECT_PATH} \
                -buildTarget Android -executeMethod BuildScript.BuildAndroid -logFile unity.log
                """
            }
        }
    }

    post {
        success {
            echo '✅ Build Exitosa!'
        }
        failure {
            echo '❌ Build Fallida!'
        }
    }
}
