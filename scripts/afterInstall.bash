docker pull 860436917626.dkr.ecr.ap-northeast-2.amazonaws.com/rainbow-api:development
docker run -d -e ASPNETCORE_ENVIRONMENT=Development --name rainbow-api -p 8081:8080 860436917626.dkr.ecr.ap-northeast-2.amazonaws.com/rainbow-api:development
