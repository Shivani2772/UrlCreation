ASP.NET CORE API with SQL SERVER for short URL creation

  You should see two endpoint "GET" and "POST"

        POST - glets you create a short url given the long url. It will return with short url (called "link" in the return model.) Enter the link you got on browser and it should redirect you to the long url.

        GET - you can enter the code from return url in POST (called "code") and it should give you redirect, check the header for the location of the long url.


1. Clone/download from (https://github.com/Shivani2772/UrlCreation) repository.

Two way to acess endpoints
    1. IIS
        1. Add new site called "local.lit.ay"(host name), http type, port 80 and physical path to the url folder.
        2. Add "127.0.0.1 local.lit.ay" to host file on your machine (etc/host) 
        3. Give permission to IIS to access your folder 
            1. Rigt click and open properties of url folder select security tab and add two usernames/group.
                a. Users and IIS_IUSRS (Allow all permissions.)
        4. Update migration.
        5. Open http://local.lit.ay/swagger/index.html in browser.
    
    2. Docker
        1. Modify the host file with (127.0.0.1 lit.ay)
        2.  Open the dir UrlCreation and search "cmd" on search of file explorer and hit enter.
        3. Once cmd opens run the command (docker-compose build). This will  build the images in the docker-compose.yml file.
        4. Once done run command (docker-compose up). THis will aggregate output of all the containers (urlcreation(api project) and urldatabase(sql server)).
        5. Open http:lit.ay:81/swagger/index.html in browser and you should see two endpoint Post and Get.
