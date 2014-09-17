DECLARE @v_counter INT;
DECLARE @FN varchar(20);
DECLARE @LN varchar(20);
SET @v_counter = 30000;
BEGIN
	WHILE @v_counter > 1
	BEGIN
		Select @FN = First_Name.Name from First_Name where First_Name.id=(ROUND(RAND()*10,0))
		Select @LN = Last_Name.Name from Last_Name where Last_Name.id=(ROUND(RAND()*10,0))
		INSERT INTO Employee (FirstName, LastName, Employee_ID, EmpPassword, Employee.Role, Location, email, Employee.Status)
		VALUES(			
			@FN,
			@LN,
			@v_counter,
			HASHBYTES('MD5', @FN),
			1,
			ROUND(RAND()*4,0),
			@FN +'.'+ @LN + '@gmail.com',
			1);
		SET @v_counter = @v_counter - 1;
	END;

END;