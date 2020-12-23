-- CREATE TABLE contractors(
--     name VARCHAR(255) NOT NULL,
--     hourly INT NOT NULL,
--     id INT NOT NULL AUTO_INCREMENT,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE profiles(
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE jobs(
--     budget INT NOT NULL,
--     title VARCHAR(255) NOT NULL,
--     location VARCHAR(255) NOT NULL,
--     id INT NOT NULL AUTO_INCREMENT,
--     PRIMARY KEY (id)
-- )

CREATE TABLE contractorJobs(
    id INT NOT NULL AUTO_INCREMENT,
    contractorId INT,
    jobId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    PRIMARY KEY (id),

    FOREIGN KEY (contractorId)
    REFERENCES contractors (id)
    ON DELETE CASCADE,

    FOREIGN KEY (jobId)
    REFERENCES jobs (id)
    ON DELETE CASCADE,

    FOREIGN KEY (creatorId)
    REFERENCES profiles (id)
    ON DELETE CASCADE
)