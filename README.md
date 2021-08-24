# learning-aws

# Docker

### Tag and push after build
``` bash
docker tag simpleonlineshop:latest ungerfall/simpleonlineshop:latest
docker push ungerfall/simpleonlineshop:latest
```

### Install docker on ec2 t2.micro
<https://docs.aws.amazon.com/AmazonECS/latest/developerguide/docker-basics.html>

``` bash
sudo yum update -y
```

``` bash
sudo yum install docker
```

``` bash
sudo service docker start
```

``` bash
sudo usermod -a -G docker ec2-user
```

### Pull SimpleOnlineShop

``` bash
docker login
```

``` bash
docker pull ungerfall/simpleonlineshop:latest
```

### Run application

``` bash
docker create -p 80:80 --name sos ungerfall/simpleonlineshop
docker start sos
```

### Get ports listening 2000

``` bash
sudo netstat -pna | grep 2000
```

