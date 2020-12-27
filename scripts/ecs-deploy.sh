if [ -z "$TRAVIS_PULL_REQUEST" ] || [ "$TRAVIS_PULL_REQUEST" == "false" ]; then
if [ "$TRAVIS_BRANCH" == "master" ]; then

# --force-new-deployment       Force a new deployment of the service. Default is false.
# --use-latest-task-def   Will use the most recently created task definition as it's base, rather than the last used.
# --skip-deployments-check     Skip deployments check for services that take too long to drain old tasks
# --run-task                   Run created task now. If you set this, service-name are not needed.

echo "Deploying $TRAVIS_BRANCH on $CLUSTER_NAME"

OLD_TASK_ID=`aws ecs list-tasks --cluster $CLUSTER_NAME --desired-status RUNNING --family $TASK_DEFINITION_API | egrep "task/" | sed -E "s/.*task\/(.*)\"/\1/"`
CUR_REVISION=$(aws ecs describe-task-definition --task-definition $TASK_DEFINITION_API --query 'taskDefinition.revision' --output text)

aws ecs stop-task --cluster $CLUSTER_NAME --task ${OLD_TASK_ID}
aws ecs deregister-task-definition --task-definition "$TASK_DEFINITION_API:${CUR_REVISION}"

ecs-deploy -t 20 -c $CLUSTER_NAME -n $SERVICE_NAME -i $AWS_ECR_ACCOUNT.dkr.ecr.ap-northeast-2.amazonaws.com/$APP_NAME:$environment
NXT_REVISION=`aws ecs describe-task-definition --task-definition $TASK_DEFINITION_API | egrep "revision" | tr "/" " " | awk '{print $2}' | sed 's/"$//'`
aws ecs update-service --cluster $CLUSTER_NAME --service $SERVICE_NAME --force-new-deployment --task-definition $TASK_DEFINITION_API:${NXT_REVISION} --desired-count 1

else
echo "Skipping deploy because it's not an allowed branch"
fi
else
echo "Skipping deploy because it's a PR"
fi