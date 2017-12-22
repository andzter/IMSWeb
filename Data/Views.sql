USE [IMSWEB]
GO

IF OBJECT_ID('vw_client', 'V') IS NOT NULL
    DROP VIEW vw_client;
GO

-- select * from vw_client

create view vw_client
AS
  select c.client_id as Clientid, title,last_name as LastName , 
      first_name as FirstName, middle_name as MiddleName, NickName, 
      CASE client_type
         WHEN '1' THEN ltrim(isnull(last_name,'') + ', ' + isnull(first_name,'') + ' ' + isnull(middle_name,''))
         WHEN '2' THEN last_name
          
      END as ClientName,
    client_type , r.description as ClientType, office_name, 
    isnull(office_building,'') + ' ' + isnull(office_street,'')  + ' ' + isnull(Office_Village,'') + ' ' + isnull(Office_City,'') + ' ' + isnull(Office_Zip,'') as OfficeAddress,
    isnull(home_street,'')  + ' ' + isnull(home_Village,'') + ' ' + isnull(home_City,'') + ' ' + isnull(Home_Zip,'') as HomeAddress,
    mailing_address,
    CASE mailing_address
         WHEN 'H' THEN 'HOME'
         WHEN 'O' THEN 'OFC'
      END as MailingAddress, 
    date_of_birth as DateofBirth,
    isnull(Month(date_of_birth),0) as BirthMonth,
    isnull(Day(date_of_birth),0) as Bday,
     cast (isnull(FLOOR(DATEDIFF(DAY, date_of_birth, getdate() ) / 365.25),0)  as varchar(10))as ClientAge
	 ,
    --cNo.ContactNo, 
	Referred_by as ReferredBy, Notes, Mobile, Phone, Email,  
     
     c.Created_by as Createdby,  c.Create_date as Createdate , c.Updated_by as Updatedby, c.Update_date as Updatedate  
  from client c
  left outer join [Ref_Client_Type] r on c.client_type = r.cd
GO
  
  --left outer join ClientNo cNo on c.client_id = cNo.client_id

 


IF OBJECT_ID('vwRepClientNoNicknames', 'V') IS NOT NULL
    DROP VIEW vwRepClientNoNicknames;
GO


create view vwRepClientNoNicknames
AS
  select * from vw_client where ISNULL(nickname,'') = ''

GO


IF OBJECT_ID('vwRepClientNoBirthdays', 'V') IS NOT NULL
    DROP VIEW vwRepClientNoBirthdays;
GO


create view vwRepClientNoBirthdays
AS
  select * from vw_client where ISNULL(DateofBirth,'') = ''

GO 


IF OBJECT_ID('vwRepClientNoMobile', 'V') IS NOT NULL
    DROP VIEW vwRepClientNoMobile;
GO


create view vwRepClientNoMobile
AS
  select * from vw_client where ISNULL(Mobile,'') = ''

GO 


IF OBJECT_ID('vwRepClientwithMobile', 'V') IS NOT NULL
    DROP VIEW vwRepClientwithMobile
GO


create view vwRepClientwithMobile
AS
  select * from vw_client where ISNULL(Mobile,'') <> ''
     and isnull(Nickname,'') = ''

GO 


IF OBJECT_ID('vwRepClientNoMobileWithEmail', 'V') IS NOT NULL
    DROP VIEW vwRepClientNoMobileWithEmail
GO


create view vwRepClientNoMobileWithEmail
AS
  select * from vw_client where ISNULL(Mobile,'') = ''
    and isnull(email,'') <> ''

GO 

IF OBJECT_ID('vwRepClientwithMobileBday', 'V') IS NOT NULL
    DROP VIEW vwRepClientwithMobileBday
GO


create view vwRepClientwithMobileBday
AS
  select * from vw_client where ISNULL(Mobile,'') <> ''
     and isnull(DateOfBirth,'') = '' 
GO 



IF OBJECT_ID('vwRepClientwithMobileEmail', 'V') IS NOT NULL
    DROP VIEW vwRepClientwithMobileEmail
GO


create view vwRepClientwithMobileEmail
AS
  select * from vw_client where ISNULL(Mobile,'') <> ''
     and isnull(Email,'') = '' 
GO 


--select date_of_birth from client
/*
update client
set date_of_birth = null
where isnull(date_of_birth,'') = ''
GO
*/

IF OBJECT_ID('uspClientBday', 'P') IS NOT NULL
    DROP Procedure uspClientBday;
GO

Create procedure uspClientBday
  @mon int
AS

   select * from vw_client
     where BirthMonth = @mon

GO