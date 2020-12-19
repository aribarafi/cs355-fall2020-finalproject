

ALTER TABLE Client
ADD Password varchar(50);

ALTER TABLE Client
ADD Username varchar(50);

UPDATE Client
SET Password = HASHBYTES('SHA1', 'Lanterman123')
WHERE idClient = 1;


UPDATE Client
SET Password = HASHBYTES('SHA1', 'Westside123')
WHERE idClient = 2;


UPDATE Client
SET Password = HASHBYTES('SHA1', 'SouthCentral123')
WHERE idClient = 3;


UPDATE Client
SET Password = HASHBYTES('SHA1', 'EastLA123')
WHERE idClient = 4;



UPDATE Client
SET Username = 'lanteman'
WHERE idClient = 1;

UPDATE Client
SET Username = 'westside'
WHERE idClient = 2;

UPDATE Client
SET Username = 'southla'
WHERE idClient = 3;

UPDATE Client
SET Username = 'eastla'
WHERE idClient = 4;

/*
select top 1 One_Way_Payment from Transport_Provider where Name = 'Care 1 Transportation' order by One_Way_Payment desc;
select * from Transport_Provider;
select * from OrderDetails

ALTER TABLE OrderDetails
ADD [Passenger Name] varchar(255);


--select * from joinODandPassenger

--UPDATE OrderDetails
--SET [Passenger Name] = (select [Name] from joinODandPassenger INNER JOIN OrderDetails where OrderDetails.idOrderDetails = joinODandPassenger.idOrderDetails);


SELECT idClient FROM Client WHERE 'lanteman' = Username

SELECT idClient FROM Client WHERE Username = 'lanteman'

*/
