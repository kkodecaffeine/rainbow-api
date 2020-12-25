docker stop rainbow-api
docker rm rainbow-api
# 이후 afterinstall.bash 파일에서 새롭게 받아온 파일을 사용하여 다시 Docker Container를 띄울 예정입니다.
# [Your Docker Container Name] 예시) woomin-facebook-codedeploy

#docker rmi -f $(docker images --format '{{.Repository}}:{{.Tag}}' --filter=reference='[Your DockerHub ID]/[Your Repository Name]:[Your version]')
docker rmi -f $(docker images --format '{{.Repository}}:{{.Tag}}')