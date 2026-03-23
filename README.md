# DevSecOps Pipeline — .NET Task Manager API

![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![Build](https://github.com/VSMANOJKUMAR/dotnet-taskapi/actions/workflows/pipeline.yml/badge.svg)

A hands-on DevSecOps project built with a fully free-tier toolchain. A simple ASP.NET Core 8 Task Manager API is used as a vehicle to learn and implement a real-world CI/CD pipeline with security scanning at every stage.

---

## Pipeline Overview

Every `git push` to `master` triggers the full pipeline automatically:
```
Push to master
      │
      ▼
Stage 1: Build & Test         → dotnet build + dotnet test
      │
      ▼
Stage 2: SonarCloud (SAST)    → source code security & quality scan
      │
      ▼
Stage 3: Trivy (Filesystem)   → repo scan for secrets & misconfigs
      │
      ▼
Stage 4: OWASP Dependency     → NuGet CVE scan
      │
      ▼
Stage 5: Docker Build + Scan  → container image CVE scan
      │
      ▼
Stage 6: Docker Push          → push to Docker Hub (:latest + :sha tag)
```

---

## Tech Stack

| Tool | Purpose | Cost |
|---|---|---|
| GitHub Actions | CI/CD runner | Free |
| SonarCloud | SAST — code quality & security | Free (public repo) |
| Trivy | Filesystem & container image scanning | Free |
| OWASP Dependency Check | SCA — NuGet CVE scanning | Free |
| Docker Hub | Container image registry | Free |
| .NET 8 | Application framework | Free |

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/tasks` | List all tasks |
| POST | `/tasks` | Create a task |
| PUT | `/tasks/{id}` | Update a task |
| DELETE | `/tasks/{id}` | Delete a task |
| GET | `/health` | Health check |

---

## Security Reports

After every pipeline run, download reports from the **Actions tab → Artifacts**:

- `trivy-fs-report` — filesystem vulnerability scan results
- `trivy-image-report` — Docker image vulnerability scan results
- `owasp-report` — NuGet dependency CVE report (HTML file)

SonarCloud dashboard shows live code quality, security hotspots, and coverage.

---

## Project Structure
```
dotnet-taskapi/
├── src/
│   └── TaskApi/
│       ├── Program.cs
│       └── TaskApi.csproj
├── tests/
│   └── TaskApi.Tests/
│       ├── UnitTest1.cs
│       └── TaskApi.Tests.csproj
├── .github/
│   └── workflows/
│       └── pipeline.yml
├── Dockerfile
├── LICENSE
└── README.md
```

---

## Run Locally

### Without Docker
```bash
cd src/TaskApi
dotnet run
```

Visit:
```
http://localhost:5000/health
http://localhost:5000/swagger
http://localhost:5000/tasks
```

### With Docker
```bash
docker build -t dotnet-taskapi:local .
docker run -p 8080:8080 dotnet-taskapi:local
```

Visit:
```
http://localhost:8080/health
http://localhost:8080/tasks
```

---

## Prerequisites

| Requirement | Details |
|---|---|
| .NET 8 SDK | For local development and testing |
| Docker Desktop | For local container builds |
| GitHub account | Public repo required for SonarCloud free tier |
| Docker Hub account | Free public image hosting |
| SonarCloud account | Free at sonarcloud.io — link to GitHub repo |

No AWS, GCP, or Azure account required.

---

## Pipeline Secrets Required

Add these in GitHub → Settings → Secrets → Actions:

| Secret Name | Description |
|---|---|
| `SONAR_TOKEN` | Generated from SonarCloud → My Account → Security |
| `DOCKERHUB_USERNAME` | Your Docker Hub username |
| `DOCKERHUB_TOKEN` | Generated from Docker Hub → Account Settings → Security |

---

## Security Layers

| Stage | Tool | What It Scans |
|---|---|---|
| SAST | SonarCloud | Source code bugs, vulnerabilities, code smells |
| SCA | OWASP Dependency Check | NuGet packages against CVE database |
| Filesystem Scan | Trivy | Repo files, secrets, misconfigurations |
| Image Scan | Trivy | Docker image OS and library CVEs |

---

## What I Learned

- Writing multi-stage Dockerfiles for .NET applications
- Structuring GitHub Actions workflows with dependent jobs and secrets
- Integrating SonarCloud quality gates into a CI pipeline
- Running Trivy in both filesystem and container image modes
- Understanding OWASP Dependency Check CVE reports and CVSS scoring
- Tagging Docker images with git SHA for full traceability
- DevSecOps principle — security built into every stage, not added at the end

---

## License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.
```

---

## LICENSE
```
MIT License

Copyright (c) 2026 VSMANOJKUMAR

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.