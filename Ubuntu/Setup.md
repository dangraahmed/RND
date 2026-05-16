# Ubuntu Development Environment Setup Guide

This guide contains tested commands and recommended installation order for setting up a fresh Ubuntu development environment.

---

# 1. Update System Packages

Always start with updating the package index and upgrading existing packages.

```bash
sudo apt update
```
```bash
sudo apt upgrade
```

---

# 2. Install Essential System Tools

## Install Git

```bash
sudo apt install git
```

## Install GitHub CLI

```bash
sudo apt install gh
```

## Install Extension Manager

```bash
sudo apt install gnome-shell-extension-manager
```

---

# 3. Install Web Browser

## Install Chromium Browser

```bash
sudo apt install -y chromium-browser
```

---

# 4. Install Development SDKs

## Install .NET SDK

```bash
sudo apt update
```

```bash
sudo apt install dotnet-sdk-10.0
```

---

# 5. Install Node.js Using NVM

## Step 1: Install NVM

```bash
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.4/install.sh | bash
```

## Step 2: Load NVM Without Restarting Terminal

```bash
\. "$HOME/.nvm/nvm.sh"
```

## Step 3: Install Node.js

```bash
nvm install 24
```

---

# 6. Install Global Node.js Tools

## Install Microsoft Inshellisense

### Installation

```bash
npm install -g @microsoft/inshellisense
```

```bash
is init
```

```bash
is init bash >> ~/.bashrc
```

---

## Install Angular CLI

```bash
npm install -g @angular/cli
```

---

# 7. Install Visual Studio Code

## Step 1: Download VS Code

Download the `.deb` package from the official website.

## Step 2: Install VS Code

```bash
sudo apt install -y ./code_*.deb
```

---

# 8. Install Docker (Engine + CLI + Compose)

## Step 1: Install Prerequisites

```bash
sudo apt update
```
```bash
sudo apt install ca-certificates curl
```

---

## Step 2: Add Docker Official GPG Key

```bash
sudo install -m 0755 -d /etc/apt/keyrings
```

```bash
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
```

```bash
sudo chmod a+r /etc/apt/keyrings/docker.asc
```

---

## Step 3: Add Docker Repository

```bash
sudo tee /etc/apt/sources.list.d/docker.sources <<EOF
Types: deb
URIs: https://download.docker.com/linux/ubuntu
Suites: $(. /etc/os-release && echo "${UBUNTU_CODENAME:-$VERSION_CODENAME}")
Components: stable
Architectures: $(dpkg --print-architecture)
Signed-By: /etc/apt/keyrings/docker.asc
EOF
```

---

## Step 4: Install Docker Packages

```bash
sudo apt update
```

```bash
sudo apt install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```

---

## Step 5: Verify Docker Installation

```bash
docker --version
```

```bash
docker compose version
```

---

## Step 6: Configure Docker for Non-Root User

### Create Docker Group

```bash
sudo groupadd docker
```

### Add Current User to Docker Group

```bash
sudo usermod -aG docker $USER
```

### Apply Group Changes

Log out and log back in

OR run:

```bash
newgrp docker
```

---

# 9. Setup Custom Shortcuts

## Step 1: Create Shortcut Directory

```bash
mkdir -p ~/sc
```

---

## Step 2: Add `sc` Folder to PATH

Open `.bashrc`

```bash
nano ~/.bashrc
```

Add the following line at the bottom:

```bash
export PATH="$HOME/sc:$PATH"
```

For Run Command in Graphical Applications:

```bash
nano ~/.profile
```

Add the following line at the bottom:

```bash
export PATH="$HOME/sc:$PATH"
```

Apply changes:

```bash
source ~/.bashrc
```

---

## Step 3: Create VS Code Shortcut

```bash
ln -s /usr/bin/code ~/sc/vs
```

---

## Step 4: Create Folder Shortcut Script

Create shortcut file:

```bash
nano ~/sc/pj
```

Add the following content:

```bash
#!/bin/bash
xdg-open ~/data/Project
```

Make the script executable:

```bash
chmod +x ~/sc/pj
```

---

# Setup Complete

Your Ubuntu system is now configured with:

* Git & GitHub CLI
* Chromium Browser
* .NET SDK
* Node.js (via NVM)
* Angular CLI
* VS Code
* Docker
* Terminal Shortcuts
* GNOME Extension Manager
