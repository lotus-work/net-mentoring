
CREATE TABLE Person (
    Id INT NOT NULL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);

CREATE TABLE Address (
    Id INT NOT NULL PRIMARY KEY,
    Street VARCHAR(50) NOT NULL,
    City VARCHAR(20),
    State VARCHAR(50),
    ZipCode VARCHAR(50)
);

CREATE TABLE Employee (
    Id INT NOT NULL PRIMARY KEY,
    AddressId INT NOT NULL,
    PersonId INT NOT NULL,
    CompanyName VARCHAR(20) NOT NULL,
    Position VARCHAR(30),
    EmployeeName VARCHAR(100),
    FOREIGN KEY (AddressId) REFERENCES Address(Id),
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

CREATE TABLE Company (
    Id INT NOT NULL PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Address(Id)
);

CREATE VIEW EmployeeInfo AS
SELECT
    E.Id AS EmployeeId,
    COALESCE(NULLIF(TRIM(E.EmployeeName), ''), CONCAT(P.FirstName, ' ', P.LastName)) AS EmployeeFullName,
    CONCAT(A.ZipCode, '_', A.State, ', ', A.City, '-', A.Street) AS EmployeeFullAddress,
    CONCAT(E.CompanyName, '(', IFNULL(E.Position, ''), ')') AS EmployeeCompanyInfo
FROM Employee E
JOIN Person P ON E.PersonId = P.Id
JOIN Address A ON E.AddressId = A.Id
ORDER BY E.CompanyName ASC, A.City ASC;

DELIMITER $$

CREATE PROCEDURE InsertEmployeeInfo (
    IN p_EmployeeName VARCHAR(100),
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_CompanyName VARCHAR(50),
    IN p_Position VARCHAR(30),
    IN p_Street VARCHAR(50),
    IN p_City VARCHAR(20),
    IN p_State VARCHAR(50),
    IN p_ZipCode VARCHAR(50)
)
BEGIN
    IF (TRIM(COALESCE(p_EmployeeName, '')) = '' AND
        TRIM(COALESCE(p_FirstName, '')) = '' AND
        TRIM(COALESCE(p_LastName, '')) = '') THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'At least one of EmployeeName or FirstName or LastName must be provided';
    END IF;

    SET p_CompanyName = LEFT(p_CompanyName, 20);

    SET @addressId = IFNULL((SELECT MAX(Id) FROM Address), 0) + 1;
    SET @personId = IFNULL((SELECT MAX(Id) FROM Person), 0) + 1;
    SET @employeeId = IFNULL((SELECT MAX(Id) FROM Employee), 0) + 1;

    INSERT INTO Address (Id, Street, City, State, ZipCode)
    VALUES (@addressId, p_Street, p_City, p_State, p_ZipCode);

    INSERT INTO Person (Id, FirstName, LastName)
    VALUES (@personId, IFNULL(p_FirstName, ''), IFNULL(p_LastName, ''));

    INSERT INTO Employee (Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
    VALUES (@employeeId, @addressId, @personId, p_CompanyName, p_Position, p_EmployeeName);
END$$

DELIMITER ;


DELIMITER $$
CREATE TRIGGER trg_after_employee_insert
AFTER INSERT ON Employee
FOR EACH ROW
BEGIN
    DECLARE nextCompanyId INT;

    IF NOT EXISTS (
        SELECT 1 FROM Company
        WHERE Name = NEW.CompanyName AND AddressId = NEW.AddressId
    ) THEN
        SELECT IFNULL(MAX(Id), 0) + 1 INTO nextCompanyId FROM Company;

        INSERT INTO Company (Id, Name, AddressId)
        VALUES (
            nextCompanyId,
            NEW.CompanyName,
            NEW.AddressId
        );
    END IF;
END$$
DELIMITER ;


INSERT INTO Address (Id, Street, City, State, ZipCode)
VALUES (1, '123 Main St', 'Austin', 'Texas', '73301');

INSERT INTO Person (Id, FirstName, LastName)
VALUES (1, 'Alice', 'Smith');

INSERT INTO Employee (Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
VALUES (1, 1, 1, 'TechCorp', 'Engineer', NULL);


SELECT * FROM EmployeeInfo;

SELECT * FROM Person;
SELECT * FROM Address;
SELECT * FROM Employee;
SELECT * FROM Company;
