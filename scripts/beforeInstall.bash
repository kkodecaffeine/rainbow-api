if [ -d /home/ubuntu/deploy ]; then
    rm -rf /home/ubuntu/deploy
fi
# 만약 /home/ubuntu/build 디렉토리가 존재하면 지운다는 의미입니다.

mkdir -vp /home/ubuntu/deploy
# 다시 새로운 /home/ubuntu/build 디렉토리를 생성합니다.

docker stop rainbow-api
docker rm rainbow-api
# 저는 Docker를 이용할 것이기 때문에, 돌가가고 있는 Docker Container를 중지시키고, 제거합니다.
# 이후 afterinstall.bash 파일에서 새롭게 받아온 파일을 사용하여 다시 Docker Container를 띄울 예정입니다.
# [Your Docker Container Name] 예시) woomin-facebook-codedeploy

#docker rmi -f $(docker images --format '{{.Repository}}:{{.Tag}}' --filter=reference='[Your DockerHub ID]/[Your Repository Name]:[Your version]')
docker rmi -f $(docker images --format '{{.Repository}}:{{.Tag}}')