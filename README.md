﻿# Ionut sandbox project for back-end course

name | value
--- | ---
language | C#
database | postgres
deployed | https://asp-net-sandbox-project.herokuapp.com

## How to run in Docker from the commandline

Navigate to [AspNetSandbox](AspNetSandbox) directory


### Build in container
```
docker build -t web_ionut .
```

to run

```
docker run -d -p 8081:80 --name web_container_borys web_ionut
```

to stop container
```
docker stop web_container_ionut
```

to remove container
```
docker rm web_container_ionut
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a webapp-sandbox-ionut web
```

Release the container
```
heroku container:release -a webapp-sandbox-ionut web
```