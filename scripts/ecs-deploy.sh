if [ -z "$TRAVIS_PULL_REQUEST" ] || [ "$TRAVIS_PULL_REQUEST" == "false" ]; then
if [ "$TRAVIS_BRANCH" == "master" ]; then

# --force-new-deployment       Force a new deployment of the service. Default is false.
# --use-latest-task-def   Will use the most recently created task definition as it's base, rather than the last used.
# --skip-deployments-check     Skip deployments check for services that take too long to drain old tasks
# --run-task                   Run created task now. If you set this, service-name are not needed.

echo "Deploying $TRAVIS_BRANCH on $CLUSTER_NAME"
ecs-deploy -t 30 -c $CLUSTER_NAME -n $SERVICE_NAME -i $AWS_ECR_ACCOUNT.dkr.ecr.ap-northeast-2.amazonaws.com/$APP_NAME:$environment

else
echo "Skipping deploy because it's not an allowed branch"
fi
else
echo "Skipping deploy because it's a PR"
fi