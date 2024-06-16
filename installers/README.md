## Ozym Docker Setup

### Overview
This procedure describes the steps for downloading the Docker latest Ozym Docker images and spinning up a local instance of the app. Further steps are included for initializing the app database and seeding sample data for the application and identity components.

### Prerequisites
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed on your system.
- Downloaded [`ozym-docker-installer.zip`](http://localhost).

### Steps

#### 1. Unpack the installation files
Unzip the `ozym-docker-installer.zip` file to a desired directory.

```sh
unzip ozym-docker-installer.zip -d PATH_TO_EXTRACT_DIRECTORY
```

#### 2. Start Docker Desktop
Ensure Docker Desktop is running. If it is not, start Docker Desktop from your applications menu.

#### 3. Run the installation script
This step will spin up the required containers and add them to the `ozym_default` network. Navigate to the directory where you unpacked the installation files and run the `ozym-docker-installer.sh` script. You will be prompted to enter two passwords:
1. Password for configuring the **sa** account.
2. Password for configuring the database user for the app.


```sh
cd PATH_TO_EXTRACT_DIRECTORY
./ozym-docker-installer.sh
```

#### 4. Initialize the database
Now that the containers are active, run the initial database login/user configuration. Start an interactive shell in the `ozym-db` container and run the database initialization script.

```sh
docker exec -it ozym-db /bin/bash init-ozym-db.sh
exit
```

**Note**: Depending on your system, you may need to modify the commands below. For example, if on Windows your input device may not be TTY, and you receive the following error:
``` sh
docker exec -it ozym-web sh
the input device is not a TTY.  If you are using mintty, try prefixing the command with 'winpty'
```

If this is the case, instead run:
``` sh
winpty docker exec -it ozym-web sh
```

#### 5. Run data migrations
The installer comes with two migration apps: **(1)** **ozymworksbundle**, and **(2)** **ozymidentitybundle**. Start an interactive shell in the `ozym-web` container and run each migration app.

```sh
docker exec -it ozym-web /bin/bash
read -p 'Enter [sa] account password: ' -s SA_PASSWORD
echo 

/app/ozymworksbundle --connection "Server=ozymdb;Database=OzymWorks;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=true"

./appidentitybundle --connection "Server=ozymdb;Database=OzymIdentity;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=true"
exit
```

#### 6. Access the Application
Find the application by navigating to the mapped port for `ozym-web`. Open your web browser and go to `http://localhost:<mapped_port>` where `<mapped_port>` corresponds to your selection in the `docker-compose.yml` file or the port auto-selected by Docker Desktop.
