USE [IMSWEB]
GO

IF OBJECT_ID('vw_client', 'V') IS NOT NULL
    DROP VIEW vw_client;
GO

create view vw_client
AS
  select c.client_id as Clientid, title,last_name as LastName , 
      first_name as FirstName, middle_name as MiddleName, nickname, 
      CASE client_type
         WHEN '1' THEN ltrim(isnull(last_name,'') + ', ' + isnull(first_name,'') + ' ' + isnull(middle_name,''))
         WHEN '2' THEN last_name
          
      END as clientname,
    client_type , r.description as clienttype, office_name, 
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
     isnull(FLOOR(DATEDIFF(DAY, date_of_birth, getdate() ) / 365.25),0) as Age,
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