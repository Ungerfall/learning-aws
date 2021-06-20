# questions

1. What hardware is offered by EC2?
--------------------------------------------------------------------------------
  * General Purpose (T, M series)
  * Compute optimized (C series)
  * Memory optimized (R, X series)
  * Accelerated computing (P, G, F series)
  * Storage optimized (I, D, H series)

2. What provisioning/billing options are available with EC2?
--------------------------------------------------------------------------------
  * Amazon Machine Image
  * Instance type
  * Storage
  * Tags
  * Security group

3. What is EBS?
--------------------------------------------------------------------------------
Amazon Elastic Block Store (EBS) is an easy to use, high-performance, 
block-storage service designed for use with Amazon Elastic Compute Cloud (EC2) 
for both throughput and transaction intensive workloads at any scale. 
A broad range of workloads, such as relational and non-relational databases, 
enterprise applications, containerized applications, big data analytics 
engines, file systems, and media workflows are widely deployed on Amazon EBS.

4. What types of volumes are offered by EC2?
--------------------------------------------------------------------------------
  * SSD (general purpose, IOPS)
  * HDD (throughput optimized, cold)
  * Magnetic volumes

5. What is the difference between AMI and snapshot in terms of EC2?
--------------------------------------------------------------------------------
  * EBS Snapshot very often represents a backup of specific EBS volume, 
it might be any volume (Root volume, data volume, etc.)
  * AMI (Amazon Machine Image) is a backup of Entire EC2 instance. 
For example, with proper configuration it's possible to create AMI 
which includes multiple EBS volumes.

6. What are regions and availability zones in AWS?
--------------------------------------------------------------------------------
  * Region is a separate geographic area
  * AZ are multiple, isolated locations within Region

7. How is it possible to install/configure software on a EC2 instance?
--------------------------------------------------------------------------------
Using ssh

8. What keys are created for each EC2 instance? What for?
--------------------------------------------------------------------------------
A key pair, consisting of a private key and a public key, is a set of 
security credentials that you use to prove your identity when connecting to 
an instance. Amazon EC2 stores the public key, and you store the 
private key. You use the private key, instead of a password, to securely 
access your instances

9. What happens to EC2 instances when they are stopped and started vs re-started?
--------------------------------------------------------------------------------
  * Rebooting an instance is much the same as with a local physical computer
  * Stop/start: new internap IP, new external IP, Elastic IP, fresh ephemeral 
storage, fresh billing

10. What is the difference between IAM roles and EC2 (VPC) security groups?
--------------------------------------------------------------------------------
IAM roles gives you access to other AWS resources, while security group
configures firewall

11. Is it possible to decrease the size of an existing EBS volume?
--------------------------------------------------------------------------------
Decreasing the size of an EBS volume is not supported. However, you can 
create a smaller volume and then migrate your data to it using 
an application-level tool such as rsync.

12. Is it possible to reuse a EBS volume for multiple instances?
--------------------------------------------------------------------------------
No

13. How is it possible to get such metadata as current region/AZ from 
--------------------------------------------------------------------------------
within a running EC2 instance?
By quering 169.254.169.254 instance metadata

14. What are the available elastic load balancer types? What is the 
key difference between them?
--------------------------------------------------------------------------------
  * Application load balancer - for load balancing of HTTP and HTTPS traffic 
and provides advanced request routing targeted at the delivery of modern 
application architectures, including microservices and containers. 
Application Load Balancer routes traffic to targets within Amazon VPC 
based on the content of the request.
  * Network load balancer - for load balancing of Transmission Control 
Protocol (TCP), User Datagram Protocol (UDP), and Transport Layer 
Security (TLS) traffic where extreme performance is required
  * Gateway load balancer - makes it easy to deploy, scale, and run 
third-party virtual networking appliances.
  * Classic load balancer - basic load balancing across multiple 
Amazon EC2 instances and operates at both the request level and 
the connection level

15. What are the key events in EC2 instance lifecycle?
--------------------------------------------------------------------------------
  * Pending
  * Running
  * Stopping
  * Stopped
  * Rebooting
  * Shutting-down
  * Terminated

16. How does load balancing works? What are its core components?
--------------------------------------------------------------------------------
  * Load balancers
  * Listeners
  * Target groups 

17. How is it possible to grant a EC2 instance permissions to access 
certain AWS resources like S3?
--------------------------------------------------------------------------------
Using IAM roles

18. What is auto-scaling? How is it related to load balancing?
--------------------------------------------------------------------------------
Helps you maintain application availability and allows you to automatically add 
or remove EC2 instances according to conditions you define
