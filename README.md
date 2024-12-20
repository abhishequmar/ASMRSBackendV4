# Archaeological Site Management and Research System Backend

## Overview
This repository contains the backend codebase for the Archaeological Site Management and Research System, built using .NET 8.0 and MongoDB. The backend provides APIs for user authentication, site management, artifact tracking, and more.

## Features
- **User Authentication**: Secure login using JWT for different roles (Admin, Archaeologist, Researcher, Visitor, Conservator).
- **RBAC**: Role-Based Access Control for managing user permissions.
- **CRUD Operations**: Fully implemented CRUD operations for Sites, Artifacts, Excavations, Publications, and more.
- **GIS Integration**: Support for mapping archaeological sites using Google maps Iframe.
- **Notification System**: Alerts for updates, discoveries, and upcoming events.

## Project Structure

### Layers
- **Controllers**: Handle incoming HTTP requests and invoke appropriate services.
- **Services**: Contain business logic for managing entities and coordinating between repositories.
- **Repositories**: Interact directly with MongoDB to perform CRUD operations.

### Key Directories
```plaintext
├── Controllers
│   ├── AuthController.cs
│   ├── SitesController.cs
│   ├── ArtifactsController.cs
│   ├── ExcavationsController.cs
│   ├── PublicationsController.cs
│   └── NotificationsController.cs
├── Services
│   ├── AuthService.cs
│   ├── SiteService.cs
│   ├── ArtifactService.cs
│   ├── ExcavationService.cs
│   ├── PublicationService.cs
│   └── NotificationService.cs
├── Repositories
│   ├── UserRepository.cs
│   ├── SiteRepository.cs
│   ├── ArtifactRepository.cs
│   ├── ExcavationRepository.cs
│   ├── PublicationRepository.cs
│   └── NotificationRepository.cs
├── Models
│   ├── User.cs
│   ├── Site.cs
│   ├── Artifact.cs
│   ├── Excavation.cs
│   ├── Publication.cs
│   └── Notification.cs
└── Program.cs
