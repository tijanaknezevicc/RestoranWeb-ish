create database restoran
use restoran

create table gost
(
	id int identity(1,1) primary key,
	ime nvarchar(30),
	prezime nvarchar(30),
	kontaktTelefon nvarchar(30),
	email nvarchar(30),
	pass nvarchar(30)
)

create table termin
(
	id int identity(1,1) primary key,
	datum date,
	vreme time
)

create table sto
(
	id int identity(1,1) primary key,
	kapacitet int
)

create table rezervacija
(
	id int identity(1,1) primary key,
	gostID int foreign key references gost(id),
	stoID int foreign key references sto(id),
	terminID int unique foreign key references termin(id)
)

--select rezervacija.id, gost.ime + ' ' + gost.prezime as gost, sto.kapacitet as 'broj osoba', termin.vreme as vreme, termin.datum as datum
--from rezervacija join gost on gost.id = gostID join sto on sto.id = stoID join termin on termin.id = terminID

GO
Create PROC dbo.gostEmail
@email nvarchar(50),
@pass nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 email FROM gost
	WHERE email = @email and pass=@pass)
	Begin
	RETURN 0
	end
	RETURN 1
END TRY
BEGIN CATCH
	RETURN @@error;
END CATCH
GO

GO
CREATE PROC dbo.gostInsert
@ime nvarchar(30),
@prezime nvarchar(30),
@telefon nvarchar(30),
@email nvarchar(50),
@pass nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
IF EXISTS (SELECT TOP 1 email  FROM gost
	WHERE email = @email  )
	Return 1
	else
	Insert Into gost(ime, prezime, kontaktTelefon, email,pass)
	Values(@ime, @prezime, @telefon, @email, @pass)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC dbo.gostUpdate
@email nvarchar(50),
@pass nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 email FROM gost
	WHERE email = @email  )

	BEGIN
	
	Update gost  Set pass=@pass  where email=@email 
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create Proc gostDelete
@email nvarchar(100)
as
BEGIN TRY
	Delete from gost where email=@email
	RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

------------------------------

GO
CREATE PROC dbo.stoInsert
@kapacitet int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	Insert Into sto(kapacitet)
	Values(@kapacitet)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC dbo.stoUpdate
@id int,
@kapacitet int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 id FROM sto
	WHERE id = @id  )

	BEGIN
	
	Update sto  Set kapacitet=@kapacitet  where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create Proc stoDelete
@id int
as
BEGIN TRY
	Delete from sto where id=@id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

--------------------------

GO
CREATE PROC dbo.terminInsert
@datum date,
@vreme time
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	Insert Into termin(datum, vreme)
	Values(@datum, @vreme)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC dbo.terminUpdate
@id int,
@datum date,
@vreme time
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 id FROM termin
	WHERE id = @id  )

	BEGIN
	
	Update termin  Set datum = @datum, vreme = @vreme where id=@id
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create Proc terminDelete
@id int
as
BEGIN TRY
	Delete from termin where id=@id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

--------------------------------

GO
CREATE PROC dbo.rezervacijaInsert
@gost int,
@sto int,
@termin int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	Insert Into rezervacija(gostID, terminID, stoID)
	Values(@gost, @termin, @sto)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC dbo.rezervacijaUpdate
@gost int,
@sto int,
@termin int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 id FROM rezervacija
	WHERE gostID = @gost  )

	BEGIN
	
	Update rezervacija Set stoID = @sto, terminID = @termin where gostID=@gost
		RETURN 0;
	END
	RETURN -1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create Proc rezervacijaDelete
@id int
as
BEGIN TRY
	Delete from rezervacija where id=@id
	RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO