# questions

1. What is IAM?
AWS Identity and Access Management (IAM) is a web service that helps you 
securely control access to AWS resources. You use IAM to control who is 
authenticated (signed in) and authorized (has permissions) to use resources.

2. What are the typical use case scenarios for IAM?
Create groups, assign policies, roles to the group then add users to group.

3. What are user groups and security groups in AWS? What’s the difference?
User group - a collection of IAM users
Security group acts as a virtual firewall for your instance to control 
inbound and outbound traffic
Security groups know nothing about users.

4. What are IAM policies?
It defines permissions for an action regardless of the method that you use 
to perform the operation.

5. What is EC2 and S3?
AWS resources (services). 
EC2 (elastic compute cloud) is basically vm. 
S3 (simple storage service) is a storage service.

6. How to allow a user to programmatically access AWS resources?
Access keys, secrets

7. What is the allow/deny priority order when policies are configured on different levels (group, user,
etc.)?
Explicit deny always overrides allow

8. What ways of managing permissions for a given user do you know?
AWS Console
CLI
AWS HTTP API

9. What places can be used by AWS CLI to gather credentials and settings?
Do not know

10. What output formats does AWS CLI support?
json
yaml
yaml-stream
text
table
