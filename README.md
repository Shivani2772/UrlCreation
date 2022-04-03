ASP.NET CORE API with SQL SERVER for short URL creation

1. Clone/download from (https://github.com/Shivani2772/UrlCreation) repository.

2. Modify the host file with (127.0.0.1 lit.ay)

3. Open the dir UrlCreation and search "cmd" on search of file explorer and hit enter.

4. Once cmd opens run the command (docker-compose build). This will  build the images in the docker-compose.yml file.

5. Once done run command (docker-compose up). THis will aggregate output of all the containers (urlcreation(api project) and urldatabase(sql server)).

6. Open http:lit.ay:81/swagger/index.html in browser and you should see two endpoint Post and Get.

7. Post lets you create a short url given the long url. This will return shortlink. Copy the shortlink.

8. Paste the link you get in browser and it will redirect you to the long url you gave. (This is get request with redirect to the long url.)