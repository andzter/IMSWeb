truncate table users
GO

insert into Users ([User_ID],[UserName],[Password],[Designation],[Initials],[Admin],[UserGroup],[Created_by],[Create_date],[Updated_by],[Update_date])
select 'rph','Raph Hidalgo','epson11','sales ','rph',0,'','jmm','5/9/2012','rmh','5/15/2013'
union select 'rbt','Von Pascua','E3132','corporate hmo renewals','VRP',0,'','rmh','1/5/2015','rmh','2/20/2015'
union select 'gea','Gladys Acuna','gabbi','Document Specialist','GEA',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'hbc','Prudence Lacorte','rrb','Accounting','PVL',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'jmm','issah mendoza','ims0924','new business projects','jmm',1,'','sys','3/12/2012','JMM','4/18/2012'
union select 'jdc','Jill Campo','12345','New Business','JDC',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'jenneth','jenneth_tattao','cheth','New Biz & Corp Renewal','JOT',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'lfh','Leah Honasan','65957','Admin Mgr','LFH',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'mrn','miggy natividad','sample','new biaz','mrn',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'rar','Ramon A. Roco','915','President','RAR',1,NULL,'sys','3/12/2012',NULL,'3/12/2012'
union select 'red','Rodelle E. Defensor','rfe','ACCOUNTS RECEIVABLE','rfe',0,'','sys','3/12/2012','JMM','4/18/2012'
union select 'rmh','ramon m. hidalgo','officeims','vice-president','rmh',1,NULL,'sys','3/12/2012',NULL,'3/12/2012'
union select 'hvp','Myra Bautista','5E4D8','BC & PCI Renewals','BLM',0,'','sys','3/12/2012','rmh','5/27/2014'
union select 'AMB','AMB','CD4BD','Sales Assistant','AMB',0,'','rmh','7/24/2012','jpo','6/5/2017'
union select 'ERS','Erna R. Santiago','raroco2014','Admin Manager','ERS',1,'','rmh','11/13/2012','jpo','7/31/2017'
union select 'test 1813','test 1813','D3604','','test',0,'','jmm','1/8/2013','jmm','1/8/2013'
union select 'acc','Arlene Cuenta','87D58','Accounting','ACC',0,'','rmh','5/15/2013','rmh','5/15/2013'
union select 'DHR','DHR','C5FB7','Sales','DHR',0,'','RMH','6/3/2013','RMH','6/3/2013'
union select 'AON','Almi Nuguid','26EFF','Blue Cross Renewals','AON',0,'','rmh','2/5/2014','rmh','2/5/2014'
union select 'EBB','ER Baring','AD6FB','Special Claims ','EBB',0,'','rmh','2/7/2014','rmh','2/7/2014'
union select 'WZB','Weng Bobiles','11AA6','New Business and Travel','WZB',0,'','rmh','10/24/2014','rmh','10/24/2014'
union select 'EHA','Oliver Flores','raroco2014','24/7 Claims Assistance','EHA',0,'','rmh','12/4/2014','rmh','12/4/2014'
union select 'HRA','Hildamarie Almocera','69199','Document Specialist','HRA',0,'','rar','1/27/2015','rar','1/27/2015'
union select 'VRP','Von Pascua','AD12F','Corporate HMO New Business & Renewals','VRO',0,'','rmh','4/14/2015','rmh','4/14/2015'
union select 'BCP','Pearl Parido','87A59','Accountant','BCP',0,'','rmh','5/5/2015','rmh','5/5/2015'
union select 'LHR','Lanz Roco','55669','sales and marketing','LHR',0,'','rmh','5/11/2015','rmh','5/11/2015'
union select 'JPO','JM Ongbico','18247','Corporate Renewals','JPO',1,'','RMH','8/10/2015','jpo','5/30/2016'
union select 'MPE','Miko Enriquez','31563','Sales & Marketing Officer','MPE',0,'','rmh','11/17/2015','rmh','11/17/2015'
union select 'ESA','Vangie Aquino','05B9B','Travel Insurance','ESA',0,'','rmh','5/13/2016','rmh','5/13/2016'
union select 'JPO','JM Ongbico','904849','Corporate Renewals','JPO',1,'','rmh','5/17/2016','jpo','5/30/2016'
union select 'GBP','Genevib Palma','42C37','Corporate Renewals','GBP',0,'','rmh','5/17/2016','rmh','5/17/2016'
union select 'jcb','Joel Begornia','raroco2014','Travel Officer','JCB',0,'','jpo','12/12/2016','jpo','12/12/2016'
union select 'DAS','Dwight Odyssey A. Santillan','4BC64','Sales','DAS',0,'','jpo','2/24/2017','jpo','2/24/2017'
union select 'GPH','Gabriel Hidalgo','7EBD4','Sales & Marketing','GPH',0,'','rmh','5/16/2017','gph','7/6/2017'
union select 'FSM','Faustino Manahan Jr','6211978','INCLUSION','FSM',1,'','jpo','6/5/2017','jpo','6/5/2017'
union select 'MPH','Mica','raroco2014','Intern','MPH',1,'','jpo','6/28/2017','jpo','6/28/2017'
Go


IF (OBJECT_ID('usp_userlogin') IS NOT NULL)
  DROP PROCEDURE usp_userlogin
GO


CREATE Procedure [dbo].[usp_userlogin]
  @user  varchar(20) = null,
  @password varchar(20)
AS
  SET NOCOUNT ON 
  select count(*) from dbo.Users where [user_id] = @user and [password] = @password
GO

