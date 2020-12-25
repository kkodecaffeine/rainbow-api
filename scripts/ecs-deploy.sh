if [ -z "$TRAVIS_PULL_REQUEST" ] || [ "$TRAVIS_PULL_REQUEST" == "false" ]; then
if [ "$TRAVIS_BRANCH" == "master" ]; then

echo "Deploying $TRAVIS_BRANCH on $CLUSTER_NAME"
ecs-deploy -c $CLUSTER_NAME -n $SERVICE_NAME -i $AWS_ECR_ACCOUNT.dkr.ecr.ap-northeast-2.amazonaws.com/$APP_NAME:$environment

else
echo "Skipping deploy because it's not an allowed branch"
fi
else
echo "Skipping deploy because it's a PR"
fi