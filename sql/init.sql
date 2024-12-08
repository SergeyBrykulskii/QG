-- Таблица для сущности Discipline
CREATE TABLE Discipline (
    Id UUID PRIMARY KEY,
    GroupId UUID NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Таблица для сущности Group
CREATE TABLE "Group" (
    Id UUID PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

-- Таблица для сущности Queue
CREATE TABLE Queue (
    Id UUID PRIMARY KEY,
    DisciplineId UUID NOT NULL,
    StartDate TIMESTAMP NOT NULL,
    IsActive BOOLEAN NOT NULL,
    FOREIGN KEY (DisciplineId) REFERENCES Discipline(Id)
);


-- Таблица для сущности User
CREATE TABLE "User" (
    Id UUID PRIMARY KEY,
    RoleId UUID NOT NULL,
    Nickname VARCHAR(255) NOT NULL
);

-- Таблица для сущности QueueUser
CREATE TABLE QueueUser (
    Id UUID PRIMARY KEY,
    QueueId UUID NOT NULL,
    UserId UUID NOT NULL,
    FOREIGN KEY (QueueId) REFERENCES Queue(Id),
    FOREIGN KEY (UserId) REFERENCES "User"(Id)
);

-- Таблица для сущности TempUser
CREATE TABLE TempUser (
    Id UUID PRIMARY KEY
);


-- Таблица для сущности UserGroup
CREATE TABLE UserGroup (
    Id UUID PRIMARY KEY,
    UserId UUID NOT NULL,
    GroupId UUID NOT NULL,
    FOREIGN KEY (UserId) REFERENCES "User"(Id),
    FOREIGN KEY (GroupId) REFERENCES "Group"(Id)
);
