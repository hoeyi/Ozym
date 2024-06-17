## Ozym Docker Setup

### Overview
Use this guide to download the latest version of the app and spin up a local instance using Docker Desktop. This process allows a user to:
* Set the passwords for the SQL accounts used by the ozym.
* Apply data migrations to provide sample data to work with.

This process uses the latest images published under the repository's packages.

### Prerequisites
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed on your system.
- [winpty](https://github.com/rprichard/winpty/) installed on your system.
- Downloaded the installer zip file from [ozym-docker-installer.zip](https://github.com/hoeyi/Ozym/releases).

### Steps

#### 1. Unpack the installation files
Unzip the `ozym-docker-installer.zip` file to the desired directory.

```sh
unzip ozym-docker-installer.zip -d <PATH_TO_EXTRACT_DIRECTORY>
```

#### 2. Start Docker Desktop
Ensure Docker Desktop is running. If it is not, start Docker Desktop from your applications menu.

#### 3. Run the installation script
This step will pull the required Docker images, spin up a container network, initialize the database with user passwords and roles, then add sample data to play with. You will be prompted for two passwords:
1. For the **[sa]** account.
2. For app database user.

```sh
cd PATH_TO_EXTRACT_DIRECTORY
./install-ozym-docker-win.sh
```

#### 4. Access the application
Find the application by navigating to the mapped port for `ozym-web`. Open your web browser and go to `http://localhost:<port>`, where **<port>** corresponds to the mapped host port in the `docker-compose.yml` file or the port auto-selected by Docker Desktop. You may also wish to explore the API Swagger documentation, which can be found at `http://localhost:<api_port>/swagger`, where **<api_port>** corresponds to the setting in the `docker-compose.yml` file. The API root can be accessed at `http://localhost:<api_port>/api/v1`.

You can alter the **host:container** port mapping for the installation in the `docker-compose` file, if desired. 