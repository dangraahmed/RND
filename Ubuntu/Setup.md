# Ubuntu Setup Guide

This document contains essential commands to set up a fresh Ubuntu system with commonly used tools and software.

---

## 🔄 System Update

```bash
sudo apt update
sudo apt upgrade
```

---

## 🌐 Install Chromium Browser

```bash
sudo apt install -y chromium-browser
```

---

## Install GIT

```bash
sudo apt install git
```

---

## Install Node

1. Download and install nvm:
```bash
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.4/install.sh | bash
```
2. In lieu of restarting the shell
```bash
\. "$HOME/.nvm/nvm.sh"
```
3. Download and install Node.js:
```bash
nvm install 24
```

---

## 💻 Install Visual Studio Code

1. Download the `.deb` package from the official website.
2. Install using:

```bash
sudo apt install -y ./code_*.deb
```

---

## 🐳 Install Docker (Engine + CLI + Compose)

### Step 1: Setup prerequisites

```bash
sudo apt update
sudo apt install ca-certificates curl
```

### Step 2: Add Docker’s official GPG key

```bash
sudo install -m 0755 -d /etc/apt/keyrings
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
sudo chmod a+r /etc/apt/keyrings/docker.asc
```

### Step 3: Add Docker repository

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

### Step 4: Install Docker

```bash
sudo apt update
sudo apt install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```

### Step 6: Verify installation

```bash
docker --version
docker compose version
```

---
