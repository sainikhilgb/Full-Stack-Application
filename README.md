# Todo System

A full-stack Todo application built with React (Vite) for the client and ASP.NET Core for the server, using PostgreSQL for data storage.

## Features

- Add, update, delete, and list todos
- RESTful API backend with ASP.NET Core
- PostgreSQL database integration
- Entity Framework Core for ORM and migrations
- Docker support for both client and server
- Modern React frontend with Vite
- TypeScript client code generation from OpenAPI

## Project Structure

todo/
├── client/         # React + Vite frontend
├── server/         # ASP.NET Core backend
│   ├── api/        # API controllers, DTOs, services
│   └── efscaffold/ # Entity Framework scaffolding


## Getting Started

## Prerequisites

- Node.js & npm
- .NET 8 SDK
- Docker (optional, for containerization)
- PostgreSQL database

### Setup

#### 1. Clone the repository

git clone https://github.com/yourusername/todo.git
cd todo

### 2. Configure Environment

- Edit server/efscaffold/.env with your PostgreSQL connection string.

### 3. Run Database Migrations

cd server/efscaffold
./scaffold.sh

### 4. Start the Server

cd server/api
dotnet run

### 5. Start the Client

cd client
npm install
npm run dev

###6. Docker (optional)

Build and run containers for client and server using the provided `Dockerfiles`.

## API Documentation

- **OpenAPI spec:** `server/api/openapi-with-docs.json`
- **Auto-generated TypeScript client:** `client/src/generated-ts-client.ts`
