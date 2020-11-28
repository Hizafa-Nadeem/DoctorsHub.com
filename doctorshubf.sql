create database doctorshub
use doctorshub
Create Table Patient ( 
    PatientID int,
    Name varchar(32), 
    Contact varchar(11),
	Residence nvarchar(200),
	Gender char,
	DOB date,
	Email varchar(32)
);


Alter Table Patient add Password varchar(20) 
Alter Table Patient alter column PatientID int NOT NULL 
Alter Table Patient alter column Name varchar(32) NOT NULL 
Alter Table Patient alter column Password varchar(20) NOT NULL 
Alter Table Patient alter column Email varchar(32) NOT NULL 
Alter Table Patient alter column Gender char NOT NULL 

Alter Table Patient add constraint UNIQUE_CONSTRAINT_Patient primary key  (PatientID) 

Alter Table Patient add constraint Gender CHECK (UPPER(Gender)='M' or UPPER(Gender)='F')
Alter Table Patient add constraint Email CHECK (Email like '%@%.%')

insert into Patient values
(1,'p1','111','a','M','01-01-2001','p@a.com','abc'),
(2,'p2','111','a','M','02-02-2002','p@a.com','abc'),
(3,'p3','111','a','M','03-03-2002','p@a.com','abc'),
(4,'p4','111','a','M','04-04-2003','p@a.com','abc')

Create Table Doctor ( 
    DoctorID int, 
    Name varchar(32), 
    Contact varchar(11),
	Residence nvarchar(200),
	Gender char,
	DOB date,
	Email varchar(32),
	Rating int
);  

Alter Table Doctor add Password varchar(20) 
Alter Table Doctor alter column DoctorID int NOT NULL 
Alter Table Doctor alter column Name varchar(32) NOT NULL 
Alter Table Doctor alter column Password varchar(20) NOT NULL 
Alter Table Doctor alter column Email varchar(32) NOT NULL 
Alter Table Doctor alter column Gender char NOT NULL 
Alter Table Doctor alter column Rating int NOT NULL 

Alter Table Doctor add constraint UNIQUE_CONSTRAINT_Doctor primary key  (DoctorID) 

Alter Table Doctor add constraint GenderD CHECK (UPPER(Gender)='M' or UPPER(Gender)='F')
Alter Table Doctor add constraint EmailD CHECK (Email like '%@%.%')
Alter Table Doctor add constraint Rating CHECK (Rating >=0 and Rating <=10)

insert into Doctor values 
(1,'d1','111','a','M','01-01-2001','p@a.com',10,'abc'),
(2,'d2','111','a','M','02-02-2002','p@a.com',10,'abc'),
(3,'d3','111','a','M','03-03-2002','p@a.com',10,'abc'),
(4,'d4','111','a','M','04-04-2003','p@a.com',10,'abc')
Create Table DoctorSpeciality ( 
    DoctorID int, 
    Qualification varchar(32)
); 

Alter Table DoctorSpeciality alter column DoctorID int NOT NULL 
Alter Table DoctorSpeciality alter column Qualification varchar(32) NOT NULL 

Alter Table DoctorSpeciality add constraint UNIQUE_CONSTRAINT_DoctorSpeciality primary key  (DoctorID,Qualification) 

Alter Table DoctorSpeciality add constraint FK_DS foreign key (DoctorID) references Doctor (DoctorID) on delete cascade
 

insert into DoctorSpeciality values
(4,'s4'),
(1,'s1'),
(2,'s2'),
(3,'s3'),
(2,'s1'),
(3,'s1'),
(3,'s2')

select * from DoctorSpeciality

Create Table Appointments ( 
    AppointmentID int,
	PatientID int, 
);  

Alter Table Appointments alter column AppointmentID int NOT NULL

Alter Table Appointments add constraint UNIQUE_CONSTRAINT_Appointments primary key  (AppointmentID) 

Alter Table Appointments add constraint FK_A foreign key (PatientID) references Patient (PatientID) on delete cascade
Alter Table Appointments add constraint FK_A2 foreign key (AppointmentID) references DoctorsAvailibility (AvailibilityID) on delete cascade


insert into Appointments values
(1,1),--1
(2,2),--2
(3,3),--3
(4,1),--1
(5,2),--1
(6,3)

Create Table DoctorsAvailibility ( 
    AvailibilityID int,
    DoctorID int, 
    Date date,
	Time time
);  

Alter Table DoctorsAvailibility alter column AvailibilityID int NOT NULL

Alter Table DoctorsAvailibility add constraint UNIQUE_CONSTRAINT_DoctorsAvailibility primary key  (AvailibilityID) 

Alter Table DoctorsAvailibility add constraint FK_DA foreign key (DoctorID) references Doctor (DoctorID) on delete cascade

insert into DoctorsAvailibility values 
(1,1,'01-01-2001','1:1'),
(2,2,'01-01-2001','1:1'),
(3,3,'01-01-2001','1:1'),
(4,1,'01-01-2001','1:1'),
(5,2,'01-01-2001','1:1'),
(6,3,'01-01-2001','1:1')

Create Table AppointmentHistory ( 
    AppointmentID int,
    Description nvarchar(300)
);  


Alter Table AppointmentHistory alter column AppointmentID int NOT NULL
Alter Table AppointmentHistory alter column Description nvarchar(300) NOT NULL

Alter Table AppointmentHistory add constraint UNIQUE_CONSTRAINT_AppointmentHistory primary key  (AppointmentID) 

Alter Table AppointmentHistory add constraint FK_AH foreign key (AppointmentID) references Appointments (AppointmentID) on delete cascade

insert into AppointmentHistory values
(1,'h1'),
(2,'h2'),
(3,'h3')

Create Table Feedback ( 
    AppointmentID int,
    Comment nvarchar(300),
	Rating int
);  

Alter Table Feedback alter column AppointmentID int NOT NULL
Alter Table Feedback alter column Rating int NOT NULL

Alter Table Feedback add constraint UNIQUE_CONSTRAINT_Feedback primary key  (AppointmentID) 

Alter Table Feedback add constraint FK_F foreign key (AppointmentID) references Appointments (AppointmentID) on delete cascade

Alter Table Feedback add constraint RatingF CHECK (Rating >=0 and Rating <=10)

insert into Feedback values
(1,'h1',1),
(2,'h2',2),
(3,'h3',3)

Create Table WaitingList ( 
	PatientID int, 
    AvailibilityID int,
    Priority int
); 

Alter Table WaitingList alter column PatientID int NOT NULL
Alter Table WaitingList alter column AvailibilityID int NOT NULL

Alter Table WaitingList add constraint UNIQUE_CONSTRAINT_WaitingList primary key  (PatientID,AvailibilityID) 

Alter Table WaitingList add constraint FK_WL foreign key (PatientID) references Patient (PatientID) on delete cascade
Alter Table WaitingList add constraint FK_WL2 foreign key (AvailibilityID) references DoctorsAvailibility (AvailibilityID) on delete cascade--?????????

Alter Table WaitingList add constraint Priority CHECK (Priority>=0)
  
insert into WaitingList values
(1,2,1),
(3,2,2),
(2,1,1)

Create Table Reminder(
reminderid int,
PatientID int,
Date date,
Time time,
Description nvarchar(50)
) 

Alter Table Reminder alter column reminderID int NOT NULL
Alter Table Reminder alter column PatientID int NOT NULL
Alter Table Reminder alter column Date date NOT NULL
Alter Table Reminder alter column Time time NOT NULL
Alter Table Reminder alter column Description nvarchar(50) NOT NULL

Alter Table Reminder add constraint UNIQUE_CONSTRAINT_Reminder primary key  (reminderid) 


Alter Table Reminder add constraint FK_R foreign key (PatientID) references Patient (PatientID)
insert into reminder values
(1,1,'01-01-2001','1:1','abc'),
(2,1,'01-01-2001','1:1','abc'),
(3,2,'01-01-2001','1:1','abc'),
(4,1,'01-01-2001','1:1','abc')

create table messagereply(
PatientID int,
DoctorID int,
Comment nvarchar(500)
)

Alter Table messagereply alter column DoctorID int NOT NULL
Alter Table messagereply alter column PatientID int NOT NULL
Alter Table messagereply alter column Comment nvarchar(500) NOT NULL

Alter Table messagereply add constraint UNIQUE_CONSTRAINT_messagereply primary key  (patientid,doctorid) 


Alter Table messagereply add constraint FK_M foreign key (PatientID) references Patient (PatientID) on delete cascade
Alter Table messagereply add constraint FK_M2 foreign key (DoctorID) references Doctor (DoctorID) on delete cascade

go



insert into messagereply values
(2,1,'hello'),
(1,3,'abc')
go

insert into Patient values
(1,'laiba imran','03231122334','cantt','F','12-30-2000','l181136@lhr.nu.edu.pk','abc'),
(2,'arooba ahmad','03231122334','wapda town','F','11-22-2000','l180991@lhr.nu.edu.pk','abc'),
(3,'hizafa nadeem','03231122334','books colony','M','01-22-1998','l181105@lhr.nu.edu.pk','abc'),
(4,'kainat asif','03231122334','gulshan ravi','F','08-03-2000','l182115@lhr.nu.edu.pk','abc')

insert into Doctor values 
(1,'Dr. Zareen Alamgir','03212345678','Fast University','F','01-01-1980','p@a.com',10,'abc'),
(2,'Dr. Asad Ullah','03212345678','Fast University','M','02-02-1985','p@a.com',10,'abc'),
(3,'Dr. Sarim Baig','03212345678','Fast University','M','03-03-1970','p@a.com',10,'abc'),
(4,'Dr. Mehak Fatima','03212345678','Fast University','F','04-04-1992','p@a.com',10,'abc')

insert into DoctorSpeciality values
(1,'MBBS'),
(1,'FCPS (part I)'),
(1,'FRCS'),
(1,'MRCP'),
(1,'MD'),
(2,'MBBS'),
(2,'FRCS'),
(2,'FCPS (part II)'),
(3,'MBBS'),
(3,'MRCP'),
(3,'FRCS'),
(4,'MBBS'),
(4,'MD')

insert into DoctorsAvailibility values 
(1,1,'06-11-2020','11:00'),
(2,1,'07-12-2020','13:01'),
(3,1,'06-13-2020','10:00'),
(4,1,'07-14-2020','01:19'),
(5,2,'06-12-2020','15:00'),
(6,2,'07-11-2020','11:16'),
(7,3,'06-18-2020','1:1'),
(8,3,'07-19-2020','13:00'),
(9,3,'06-20-2020','17:19'),
(10,3,'07-23-2020','16:00'),
(11,4,'06-28-2020','01:00'),
(12,4,'07-26-2020','1:16')

insert into Appointments values
(1,1),
(2,1),
(5,1),
(7,2),
(11,2)

insert into AppointmentHistory values
(1,'i had flu and fever. and tested positive for corona :( '),
(2,'i had fever and i was suffering from diarrhea '),
(5,'i was unable to breathe and had to be shifted to ICU'),
(7,'i was suffering from asthama')

insert into Feedback values
(7,'h1',10)


--procedures
--5 add availablity
--return (0=Doctor id does not exist) (1=docttor's avialibility added) (2=date or time is null) (3=such availibility already exists)
--drop procedure AddAvailibility
go
create procedure AddAvailibility
@DocID int,@Date5 date,@Time5 time,@flag int output
as begin
if exists(select * from Doctor where Doctor.DoctorID=@DocID)
begin
 if(@Date5 is not null and @Time5 is not null)
 begin
  if exists(select * from DoctorsAvailibility where DoctorsAvailibility.DoctorID=@DocID and DoctorsAvailibility.Date=@Date5 and DoctorsAvailibility.Time=@Time5)
  begin
   print('You have already entered this availibility')
   set @flag=3
  end
  else 
  begin
   print('Availibility of doctor with Doctor ID '+cast(@DocID as varchar(10))+' added ')
   set @flag=1
   insert into DoctorsAvailibility values((select max( DoctorsAvailibility.AvailibilityID)+1 from DoctorsAvailibility),@DocID,@Date5,@Time5)
  end 
 end
 else
  begin
  print('date and time cannot be null')
  set @flag=2
 end
 end
else
begin
 print('No such doctor with Doctor ID '+cast(@DocID as varchar(10))+' exists')
 set @flag=0
end
end
go
--test code
declare @flag5 int
exec AddAvailibility
@DocID=3,@Date5='1-1-2000',@Time5='1:1',@flag=@flag5 output

select @flag5

select *
from DoctorsAvailibility

--10--appointmnet history
--(0=id not found) (1=history added) (2=discription null not allowed)  (4=history already added)
--drop procedure addhistory
go
create procedure addhistory
@pat int,
@ID int,@Descrip nvarchar(300),@flag int output
as begin
begin
if exists((select * from Appointments where Appointments.AppointmentID=@ID and Appointments.PatientID=@pat))
begin
 if(@Descrip is null)
 begin
  print('Null description not allowed')
  set @flag=2
 end
 else
 begin
  
   if exists( (select * from AppointmentHistory where AppointmentHistory.AppointmentID=@ID))
   begin
    print('Histoy already exists')
	set @flag=4
   end
   else
   begin
    print('Appointment History added')
    set @flag=1
    insert into AppointmentHistory values(@ID,@Descrip)
   end
  
 end
end

else
begin
print('Appointment id not found')
set @flag=0
end
end
end
go

declare @flag10 int
exec addhistory
@pat=1, @ID=5,@Descrip='h5',@flag=@flag10 output

select @flag10

select *
from AppointmentHistory


--11--doctors speciality
--(0=doctor id not found) (1=speciality added) (2=speciality already exists) (3=qualification was null)
--drop procedure AddSpeciality
go
create procedure AddSpeciality
@ID int,@Qualif varchar(32),@flag int output
as begin
if exists((select * from Doctor where Doctor.DoctorID=@ID))
begin
 if exists((select * from DoctorSpeciality where DoctorSpeciality.DoctorID=@ID and upper(DoctorSpeciality.Qualification)=upper(@Qualif)))
 begin
  print('this Qualification already exists')
  set @flag=2
 end
 else
 begin
  if(@Qualif is not null)
  begin
   print('Qualification added')
   set @flag=1
   insert into DoctorSpeciality values(@ID,@Qualif)
  end
  else
  begin
   print('you cannot enter a null qualification')
   set @flag=3
  end
 end
end
else
begin
 set @flag=0
 print('Doctor Not Found!')
end
end
go

declare @flag11 int
exec AddSpeciality
@ID=3,@Qualif='S',@flag=@flag11 output


--procedure 7
--return flag=1 when doctor exsits else return flag=0
--drop procedure DoctorsProfile2
go
CREATE PROCEDURE DoctorsProfile2
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has profile:'
 set @flag=1
 select doctor.DoctorID,doctor.Name,doctor.Gender,doctor.DOB,doctor.Contact,doctor.Email,doctor.Residence,doctor.Rating,DoctorSpeciality.Qualification
 from Doctor join DoctorSpeciality on Doctor.DoctorID=DoctorSpeciality.DoctorID
 where Doctor.DoctorID=@doctorid
End
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go
go

go
CREATE PROCEDURE DoctorsProfile
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has profile:'
 set @flag=1
 select doctor.DoctorID,doctor.Name,doctor.Gender,doctor.DOB,doctor.Contact,doctor.Email,doctor.Residence,doctor.Rating
 from Doctor 
 where Doctor.DoctorID=@doctorid
End
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go
 
declare @flag7 int
exec DoctorsProfile2
@doctorid=1,@flag=@flag7 output


--procedure 6
--return flag=1 when speciality exsits else return flag=0
--drop procedure HighestRatedDoctor
go

CREATE PROCEDURE HighestRatedDoctor
@speciality varchar(32),@flag int output
AS BEGIN
IF EXISTS (SELECT DoctorSpeciality.Qualification FROM [DoctorSpeciality] WHERE UPPER( DoctorSpeciality.Qualification)=UPPER(@speciality))
BEGIN
set transaction isolation level read uncommitted
begin transaction
 print'The highest rating of doctor with speciality '+@speciality+' is:'
 set @flag=1
 select Doctor.DoctorID,Doctor.Name,Doctor.Gender,Doctor.DOB,Doctor.Contact,Doctor.Email,Doctor.Residence,max(Doctor.Rating) as Rating--, count(Appointments.AvailibilityID) as number_of_Appointments 
 from ((DoctorSpeciality join Doctor on DoctorSpeciality.DoctorID=Doctor.DoctorID) join DoctorsAvailibility on DoctorsAvailibility.DoctorID=Doctor.DoctorID) join Appointments on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID
 where UPPER(qualification)=UPPER(@speciality) --AND Appointments.status='P'
 group by Doctor.DoctorID,Doctor.Name,Doctor.Contact,Doctor.Residence,Doctor.DOB,Doctor.Gender,Doctor.Email
 having count(Appointments.AppointmentID) in (select top(1) count(Appointments.AppointmentID) 
                                               from Appointments join DoctorsAvailibility on DoctorsAvailibility.AvailibilityID=Appointments.AppointmentID
											   where DoctorsAvailibility.DoctorID in (select DoctorSpeciality.DoctorID
											                                                                        from DoctorSpeciality
																													where upper(  DoctorSpeciality.Qualification)=UPPER(@speciality)
																													)
                                               group by DoctorsAvailibility.DoctorID
											   order by count( Appointments.AppointmentID ) DESC
											   )
commit
set transaction isolation level read committed
END
ELSE 
BEGIN
 PRINT 'NO DOCTOR WITH SUCH SPECIALITY EXSITS'
 set @flag=0
END
END
go

declare @flag6 int
exec HighestRatedDoctor
@speciality='s1',@flag=@flag6 output
select * from appointmentHistory

--procedure 8
--return flag=1 when patient history exsits,flag=2 when no appointment history, else return flag=0 when no patient exists
--drop procedure patienthistory_info
go
CREATE PROCEDURE patienthistory_info
@patientid int,
@flag int output
AS
BEGIN
if exists(select Patient.PatientID from patient where patientid=@patientid)
begin
IF EXISTS (SELECT Appointments.PatientID FROM [Appointments] WHERE Appointments.PatientID=@patientid)
Begin
print'The history and info of patient with patient id '+cast(@patientid as varchar(11))+' is:'
set @flag=1
select Patient.PatientID,Patient.Name,Patient.gender,Patient.contact,Patient.residence,Patient.DOB,Patient.Email,Appointments.AppointmentID,doctor.doctorid,doctor.name,AppointmentHistory.description
from Appointments join patient on patient.patientid=appointments.patientid join DoctorsAvailibility on DoctorsAvailibility.AvailibilityID=Appointments.AppointmentID join doctor on doctor.doctorid=DoctorsAvailibility.doctorid left join AppointmentHistory on AppointmentHistory.appointmentid=appointments.appointmentid 
where Appointments.patientid=@patientid 
End
else
begin
print('Patient with patient id '+cast(@patientid as varchar(11))+' has no appointment history')
set @flag=2
end
end
else
Begin
print 'No Patient of patient id '+cast(@patientid as varchar(11))+' exists'
set @flag=0
End
End
go
declare @flag6 int
exec patienthistory_info
@patientid=2,@flag=@flag6 output
go
--drop procedure patienthistory_info
go
select *
from Appointments


-- procedure 12
drop procedure cancel_appointment6
go
create procedure cancel_appointment6
@id int,
@appointment int ,@flag12 int output
as 
begin
	declare @pat int
	if(@appointment is null)
	begin
	print('Appointment id is not Entered')
	set @flag12 = 1
	end
	else if (@appointment in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@appointment and CONVERT(Date, GETDATE())=DoctorsAvailibility.date and CONVERT(TIME, GETDATE())>=doctorsavailibility.time))
	begin
	print('Time of availability has passed')
	set @flag12 =6
	end
	else if(@appointment in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@appointment and CONVERT(Date, GETDATE())>DoctorsAvailibility.date))
	begin
	print('Date of availability has  passed')
	set @flag12 =5
	end
	
	else 
	begin 
		if(@appointment in(select Appointments.AppointmentID from Appointments where Appointments.PatientID=@id))
		begin 
			--select @avail = Appointments.AppointmentID from Appointments where Appointments.AppointmentID = @appointment
			  -- get availability id for that appointment
			--update Appointments
			--set Status ='A'
			--where AppointmentID = @appointment
			
			declare @body nvarchar(100)= 'Your appointment of Appointment id '+cast(@appointment as nvarchar(20))+' has been cancelled.' 
			declare @email nvarchar(30)
			select @email=patient.email
			from Appointments join patient on Patient.PatientID=Appointments.PatientID
			where Appointments.AppointmentID=@appointment
			--select @email
			EXEC msdb.dbo.sp_send_dbmail  
			@profile_name = 'Doctors Hub',  
			@recipients = @email,  
			@subject = 'Appointment Cancelation',  
			@body = @body,
			@importance='HIGH'
			delete from appointments where AppointmentID = @appointment
			set @flag12 = 0
			if(@appointment in (select WaitingList.AvailibilityID  from WaitingList)) -- if the cancelled appointment availability exist in waiting list
			begin
					select @pat = PatientId from WaitingList  -- select patient from waiting list who wants this availability
					where WaitingList.AvailibilityID = @appointment
					and priority  =  (select min(priority) from WaitingList 
					where WaitingList.AvailibilityID = @appointment)

				-- insert into Appointments from waiting list
				insert into Appointments  values(@appointment,@pat)

				-- delete from waiting list the patient which is added in appointment 
				delete from WaitingList where WaitingList.PatientID =@pat and AvailibilityID = @appointment

				set @flag12 = 0
				print('Appointment is cancelled and availabilty is given to patient who was waiting')
			end
			
		end
		else
		begin
		set @flag12= 2
		print('No such Apointment with Appointment ID '+cast(@appointment as varchar(11))+' exist')
		end
	end 
end
go


go
declare @f12 int 
execute cancel_appointment6
@id=5,
@appointment=11,@flag12 = @f12 output

select * from Appointments
select * from AppointmentHistory
select * from WaitingList
select * from DoctorsAvailibility
--update DoctorsAvailibility
--set Time= '05:00' 
--where DoctorsAvailibility.AvailibilityID =1



-- Procedure 3
--drop procedure bookappointment4
go
Create procedure bookappointment4-- return 0 if inserted 1 if patient is null 2 if availabity is null 3 doctor is not available
@patient int,
@availibility int,
@flag int output
As
Begin
if (@patient is null )
begin
 print('Patient id is not inserted')
 set @flag =1
end
else if (@availibility is null )
begin
 print('AvaiibiltyID  is not inserted')
 set @flag =2
end
else if(@patient not in (Select Patient.PatientID from Patient))
begin
 print('No such patient found')
 set @flag =3
end
else if(@availibility not in (select DoctorsAvailibility.AvailibilityID from DoctorsAvailibility))
begin
 print('No such availibility found')
 set @flag =4
end
else if (@availibility in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@availibility and CONVERT(Date, GETDATE())=DoctorsAvailibility.date and CONVERT(TIME, GETDATE())>doctorsavailibility.time))
	begin
	print('Time of availability has passed')
	set @flag =6
	end
	else if(@availibility in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@availibility and CONVERT(Date, GETDATE())>DoctorsAvailibility.date))
	begin
	print('Date of availability has  passed')
	set @flag =5
	end
else
begin
set transaction isolation level serializable
begin transaction
 if( @availibility in (Select Appointments.AppointmentID from Appointments))
 begin
  set @flag = 7 --  availabity already booked
  print('This Availability is already reserved you may add yourself in waiting list')--same  patient
 end
 else
 begin
   Insert into Appointments values (@availibility,@patient)
  
  print('Appointment is booked')
  set @flag = 0
 end
commit
set transaction isolation level read committed
end
End


select * from Appointments

declare @f int
execute bookappointment4
@availibility=11,
@patient = 5,
@flag = @f output

select @f



-- Procedure 9
--drop procedure insert_waiting_list2
go
create procedure insert_waiting_list2
@patient int,
@availability int ,
@flag9 int output
as
begin

if(@patient is null )
begin
 print('Patient id is not Entered')
 set @flag9 = 3
end
else if(@availability is null )
begin
 print('Availabity id is not Entered')
 set @flag9 = 4
end
else if(@patient not in (select Patient.PatientID  from Patient ))
begin
 print('No such Patient with  PatientId '+cast(@patient as varchar(11))+' exist')
 set @flag9 = 1
end
else if(@availability not in (select DoctorsAvailibility.AvailibilityID from DoctorsAvailibility ))
begin
 print('No such Availability with  AvailabilityId '+cast( @availability as varchar(11))+' exist')
 set @flag9 = 2
end
else if(@availability not in (select AppointmentID from Appointments ))
begin
 print('Availability with AvailabilityId '+cast( @availability as varchar(11))+'is not reserved as an Appointment ')
 set @flag9 = 5
end
else if(exists (select * from WaitingList where AvailibilityID = @availability and PatientID = @patient))
begin
 set @flag9 = 8
 print('Your request for Availabilty '+cast(@availability as varchar(11))+'  is already present in  waiting list')
end
else if(exists (select * from Appointments where AppointmentID = @availability and PatientID = @patient ))
begin
 set @flag9 = 7
 print('You have already taken Availabilty with AvailabityID'+cast(@availability as varchar(11))+' as an appointment')
end

else if (@availability in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@availability and CONVERT(Date, GETDATE())=DoctorsAvailibility.date and CONVERT(TIME, GETDATE())>doctorsavailibility.time))
	begin
	print('Time of availability has passed')
	set @flag9 =6
	end
	else if(@availability in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@availability and CONVERT(Date, GETDATE())>DoctorsAvailibility.date))
	begin
	print('Date of availability has passed')
	set @flag9=5
	end
else
begin
 if not exists (select * from WaitingList where AvailibilityID = @availability) -- if any availibity with this
 begin
  insert into WaitingList values(@patient,@availability,0) -- if no availibility  with this id is present then set priority 0  
 end
 else
 begin
  insert into WaitingList values(@patient,@availability,(select  max(priority)+1 from WaitingList where AvailibilityID = @availability))
 end
 set @flag9 = 0
 print('Appointment is inserted in waiting list')
end
end

declare @f9 int
execute insert_waiting_list2
@availability=4,
@patient = 1,
@flag9 = @f9 output
--if no one is appointe with this  availibility then dont add and print a message to insert in appointment
select @f9

select * from doctor
--2--signup
--drop procedure SignUp2
go
create procedure SignUp2
@Name varchar(32), 
@Contact varchar(11),
@Residence nvarchar(200),
@Gender char,
@DOB date,
@Email varchar(32),
@Password varchar(20),
@isdoc int,
@rPassword varchar(20),
@flag int output


as begin
if(@Name is null)
begin
 print('Please enter your name')
 set @flag=0
end
else if(@Password is null)
begin
 print('Please enter your password')
 set @flag=0
end
else if(@Email is null)
begin
 print('Please enter your email')
 set @flag=0
end
else if(@Gender is null)
begin
 print('Please enter your gender')
 set @flag=0
end
else if(@isdoc is null)
begin
 print('Please enter whether you are patient or doctor')
 set @flag=0
end
else if(@Password !=@rPassword COLLATE SQL_Latin1_General_CP1_CS_AS)
begin
 print('Password does not match!')
 set @flag=0
end
else if(UPPER(@Gender)!='M' and UPPER(@Gender)!='F')
begin
 print('Incorrect Gender')
 set @flag=0
end
else if(@Email not like '%@%.%')
begin
 print('Incorrect Email')
 set @flag=0
end
else
begin
 print('Thank you for signing in!!!')
 set @flag=1
 if(@isdoc=1)
 begin
  if not exists (select * from Doctor) 
  begin
   set @flag=1
   insert into Doctor values(1,@Name, @Contact,@Residence,@Gender,@DOB,@Email,10,@Password)   
  end
  else
  begin
   (select @flag= max(Doctor.DoctorID)+1 from Doctor)
   insert into Doctor values((select  max(Doctor.DoctorID)+1 from Doctor),@Name, @Contact,@Residence,@Gender,@DOB,@Email,10,@Password)
  end
 end
 else
 begin
  if not exists (select * from Patient) 
  begin
   set @flag=1
   insert into Patient values(1,@Name, @Contact,@Residence,@Gender,@DOB,@Email,@Password)  
  end
  else
  begin
   (select @flag= max(Patient.PatientID)+1 from Patient)
   insert into Patient values((select  max(Patient.PatientID)+1 from Patient),@Name, @Contact,@Residence,@Gender,@DOB,@Email,@Password)
  end
 end
end
end
go

go
declare @flagu int
execute SignUp2
@Name='Kainat', 
@Contact=Null,
@Residence=NULL,
@Gender='m',
@DOB=NULL,
@Email='abc@xyz.com',
@Password='abc',
@isdoc=1,@flag=@flagu output

select @flagu
 select * from Doctor


--4--feedback
--drop procedure GiveFeedback
go
create procedure GiveFeedback
@pat int,
@AppointmentID int,
@Comment nvarchar(300),
@Rating int,
@flag int output
as begin
if(@AppointmentID is null)
begin
 print('Please enter appointment id')
 set @flag=0
end
else if(@Rating is null)
begin
 print('Please enter Rating of the doctor')
 set @flag=0
end
else if(@Rating<0 or @Rating>10)
begin
 print('Please enter a valid rating')
 set @flag=0
end
else if (@AppointmentID in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@AppointmentID and CONVERT(Date, GETDATE())=DoctorsAvailibility.date and CONVERT(TIME, GETDATE())>=doctorsavailibility.time))
	begin
	print('Time of availability has not passed')
	set @flag =6
	end
else if(@AppointmentID in (select  DoctorsAvailibility.AvailibilityID from DoctorsAvailibility where AvailibilityID =@AppointmentID and CONVERT(Date, GETDATE())<DoctorsAvailibility.date))
begin
print('Date of availability has not  passed')
set @flag =5
end
else if(@AppointmentID in(select Appointments.AppointmentID from Appointments where Appointments.PatientID=@pat))
begin
if  not exists(select * from Feedback where Feedback.AppointmentID=@AppointmentID)
begin
set @flag=3
 insert into Feedback values(@AppointmentID,@Comment,@Rating)
 print('Feedback inserted')
 declare @docid int
 select @docid=DoctorsAvailibility.DoctorID
 from DoctorsAvailibility join Appointments on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID
 where Appointments.AppointmentID=@AppointmentID
 --doctor id has id of doctor of input appointment
 declare @rate int
 select @rate=(select avg(Feedback.Rating) from (Feedback join Appointments on Appointments.AppointmentID=Feedback.AppointmentID) join DoctorsAvailibility on DoctorsAvailibility.AvailibilityID=Appointments.AppointmentID where DoctorsAvailibility.DoctorID=@docid)
 update Doctor set Rating=@rate where DoctorID=@docid
end
else 
begin
 print('You have already entered your feedback')--if he wants to edit?
 set @flag=2
end
end
else
begin
  print('Appointment not found')
 set @flag=1
end
end

go

declare @flagx int
execute GiveFeedback
@pat=1,
@AppointmentID =1,
@Comment=null,
@Rating=10,@flag=@flagx output

select * from doctor
select * from Feedback
select * from patient
select *from Appointments
select *from AppointmentHistory
select *from DoctorsAvailibility

--1--- LOGINN
--drop procedure checklogindetails 
go
create procedure checklogindetails 
@inputid int, 
@inputtype int, 
@inputpass varchar(20), 
@flag int output 
AS BEGIN 
if(@inputtype = 2)
begin
set @flag=3
end
else
begin
IF (@inputtype = 1)-- is doc
BEGIN 
 if exists ( select DoctorID from Doctor where DoctorID=@inputid )
 BEGIN 
  if exists (select Doctor.[Password] from Doctor where Password=@inputpass COLLATE SQL_Latin1_General_CP1_CS_AS)
  BEGIN 
   print('Thank you for logging in!!!')
   set @flag = 2
  END
  else 
  BEGIN
   print('Invalid Password for Doctor')
   set @flag =1
  END
 END 
 else 
 BEGIN 
  set @flag = 0
  print('Invalid Doctor ID')
 END 
END 
else if (@inputtype=0) 
BEGIN 
 if exists ( select * from Patient where @inputId = PatientID )
 BEGIN 
  if exists (select Patient.[Password] from Patient where Password=@inputpass COLLATE SQL_Latin1_General_CP1_CS_AS)
  BEGIN 
   set @flag = 2
   print('Thank you for logging in!!')
  END
  else 
  BEGIN
   print('Invalid Password for Patient')
   set @flag =1
  END 
 END 
 else 
 BEGIN 
  set @flag = 0
  print ('Invalid Patient ID')
 END
END 
end			
END 

-- 0 Patient
-- 1 Doctor 
-- Flag = 1 if Password valid 
-- 2 if Both valid 
-- 0 if non valid

declare @flag1 int
execute checklogindetails
@inputid=1, 
@inputtype=1, 
@inputpass='abc', 
@flag =@flag1 output

select * from Doctor
select * from Patient

--Procedure to take patient id and display appointments//ab

go
--drop procedure DisplayAppointmentss
go

create procedure DisplayAppointmentss
@inputPatID int,
@flag int  OUTPUT
as BEGIN
if exists (select *
from Patient left join Appointments on Appointments.PatientID = Patient.PatientID
where Patient.PatientID=@inputPatID
)
BEGIN
 if exists (select *
 from Appointments 
 where Appointments.PatientID=@inputPatID
 )
 begin
 select Appointments.AppointmentID,DoctorsAvailibility.Date,DoctorsAvailibility.Time,DoctorsAvailibility.DoctorID
 from Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID
 where Appointments.PatientID=@inputPatID 
 order by date asc
 set @flag = 1
 END
 else 
 BEGIN
 print 'Patient has no appointment'
 set @flag = 2
 END
 end
else
BEGIN
print 'No such patient id exsist'
set @flag = 0
END
END

go
declare @outputflag int
execute DisplayAppointmentss
@inputPatID = '5', @flag = @outputflag OUTPUT
select @outputflag as Flag

select * from Appointments

go
--2--Display all doctors
--drop procedure DisplayDoctors
go
create Procedure DisplayDoctors2
as
BEGIN
 select DoctorID, Name, Contact, Gender, Rating, Email
 from Doctor
END

go
execute DisplayDoctors2
--flag = 0 if no doctor exists
--flag = 1 and display doctors


--3--Display all doctors of a given speciality
--drop procedure Doctors_Acc_Speciality
go
create procedure Doctors_Acc_Speciality
@inputspeciality varchar(32) ,
@flag int OUTPUT
as BEGIN
if exists (select Doctor.DoctorID
           from Doctor join DoctorSpeciality on Doctor.DoctorID=DoctorSpeciality.DoctorID
           where DoctorSpeciality.Qualification = @inputspeciality
           )
BEGIN
 select  Doctor.DoctorID, Name, Gender,DOB, Contact, Email,Residence, Rating
 from Doctor join DoctorSpeciality on Doctor.DoctorID=DoctorSpeciality.DoctorID
 where DoctorSpeciality.Qualification=@inputspeciality
 set @flag = 1
END
else
BEGIN
 set @flag = 0
 print('No doctor with this sepciality exists')
END
END

declare @outputflag int

execute Doctors_Acc_Speciality
@inputspeciality = 's1',
@flag = @outputflag OUTPUT

select @outputflag as Flag
--flag = 0 if no doctor exists
--flag = 1 and display doctors 

--procedure 15
--return flag=1 when appointment,flag=2 no appointment,flag=3 not available else return flag=0
--drop procedure allappointmenttt
go
CREATE PROCEDURE allappointmenttt
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
IF EXISTS (SELECT DoctorsAvailibility.DoctorID FROM DoctorsAvailibility WHERE DoctorsAvailibility.DoctorID =@doctorid)
begin
IF EXISTS (SELECT DoctorsAvailibility.DoctorID FROM DoctorsAvailibility join Appointments on DoctorsAvailibility.AvailibilityID=Appointments.AppointmentID WHERE DoctorsAvailibility.DoctorID =@doctorid)
begin
 print'Doctor with doctor Id '+ cast(@doctorid as varchar(11))+ ' has appointments:'
 set @flag=1
 select Appointments.AppointmentID,Appointments.PatientID
 from Doctor join DoctorsAvailibility on Doctor.DoctorID=DoctorsAvailibility.DoctorID join Appointments on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID
 where DoctorsAvailibility.DoctorID=@doctorid 
 order by DoctorsAvailibility.Date ASC
End
else
begin
 print 'Doctor has no appointments!'
 set @flag=2
 end
 end
 else
  print 'Doctor is not available!'
 set @flag=3
 end
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go
 
declare @flag7 int
exec allappointmenttt
@doctorid=4,@flag=@flag7 output
select @flag7
select * from DoctorsAvailibility
select * from Appointments

select *from Doctor
--procedure 16
--return flag=1 when doctor's qualification else return flag=0
--drop procedure allspeciality
go
CREATE PROCEDURE allspeciality
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has speciality:'
 set @flag=1
 select DoctorSpeciality.Qualification
 from Doctor join DoctorSpeciality on Doctor.DoctorID=DoctorSpeciality.DoctorID
 where Doctor.DoctorID=@doctorid
End
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go
 
declare @flag7 int
exec allspeciality
@doctorid=3,@flag=@flag7 output

create view Specialities
as
select * from DoctorSpeciality

select * from Specialities

---procedure 17
--return flag=1 when doctor's availability,flag=2 not availability else return flag=0

go
--drop procedure allavailibility
CREATE PROCEDURE allavailibility
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
IF EXISTS (SELECT DoctorsAvailibility.DoctorID FROM DoctorsAvailibility WHERE DoctorsAvailibility.DoctorID =@doctorid)
begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has availibility:'
 set @flag=1
 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time
 from Doctor join DoctorsAvailibility on Doctor.DoctorID=DoctorsAvailibility.DoctorID
 where DoctorsAvailibility.DoctorID=@doctorid
 order by DoctorsAvailibility.Date ASC
End
 else
  print 'Doctor is not available!'
 set @flag=2
 end
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go
 
declare @flag7 int
exec allavailibility
@doctorid=1,@flag=@flag7 output
select @flag7
select * from DoctorsAvailibility


go

select * from Reminder
--procedure add reminder
-- flag=0 no such patient exists, flag=1 values inserted,flag=2 date time cannot be null, flag=3 already entered the reminder 
create procedure addreminder
@patientid int,@date date,@time time,@description nvarchar(50),@flag int output
as begin
if exists (select *from patient where patient.PatientID=@patientid)
begin
 if(@date is not null and @time is not null)
 begin
 if exists(select * from Reminder where Reminder.PatientID=@patientid and Reminder.Date=@date and Reminder.Time=@time)
 begin
  print('You have already entered this reminder!')
   set @flag=3
 end
 else
 begin
  print('Reminder of patient with Patient ID '+cast(@patientid as varchar(10))+' added ')
   set @flag=1
   if exists (select * from reminder)
   begin
   insert into Reminder values((select max( Reminder.reminderid)+1 from Reminder),@patientid,@date,@time,@description)
   end
   else
   begin
   insert into Reminder values(1,@patientid,@date,@time,@description)
   end
 end
end
else 
begin
print('Date and Time cannot be null')

set @flag=2
end
end
else
 begin
 print('No such patient with Patient ID '+cast(@patientid as varchar(10))+' exists!')

 set @flag=0
 end
 end
 go
 go

 declare @flag5 int
exec addreminder
@patientID=4,@Date='6-11-2020',@Time='1:27',@description='hello',@flag=@flag5 output
select @flag5
select *
from reminder
go

 --delete reminder
 --drop procedure deletereminderrr
 -- flag=0 no patient id, flag=1 not entered,flag=2 invalid date or time,flag=3 no reminder ,flag =4 reminder deleted
 create procedure deletereminderrr
@rid int,@pid int ,@flag int output
as begin
if(@rid is null)
begin 
print 'Reminder id is not entered'
set @flag=1
end
else if(@pid is null)
begin 
print 'Patient id is not entered'
set @flag=1
end
else
begin
 if exists (select *from Reminder where reminder.reminderid=@rid and Reminder.PatientID=@pid)
 begin
  print('Reminder of patient with Patient ID '+cast(@pid as varchar(10))+' deleted ')
  delete from Reminder 
  where Reminder.reminderid=@rid
  set @flag=4
 end
 else 
 begin
 print 'No such reminder exsist'
 set @flag=3
 end
end
end
 go

 declare @flag5 int
exec deletereminderrr
@patientID=3,@Date='1-1-2000',@Time='1:1',@des='hello',@flag=@flag5 output
select @flag5
select *
from reminder
go
 --procedure display reminder
 -- flag=0 no patient id exists,flag=1 no reminder of patient,flag=2 display reminders
 create procedure displayreminderdata
 @pid int,@flag int output
 as begin
 if exists (select *from patient where patient.PatientID=@pid)
 begin
  if exists (select *from reminder where reminder.PatientID=@pid)
  begin
  print('Patient ID '+cast(@pid as varchar(10))+' has reminder')
  set @flag=2
  select reminder.reminderid,reminder.date,reminder.time,reminder.description
  from reminder 
  where Reminder.PatientID=@pid
  order by Reminder.Date ASC
  end
  else
  begin
   print('No reminder with Patient ID '+cast(@pid as varchar(10))+' exists')
 
 set @flag=1
  end
 end
 else
 begin
  print('No such patient with Patient ID '+cast(@pid as varchar(10))+' exists')
 
 set @flag=0
 end
 end
 go

  declare @flag5 int
exec displayreminderdata
@pID=5,@flag=@flag5 output
select @flag5
go

go
create procedure editContact
@id int,
@isdoc int,
@contact varchar(11),
@flag int output
as begin
if(@contact is null)
begin
 set @flag=0;
 print('enter a contact')
end
else if(@id is null)
begin
 set @flag=0;
 print('enter an id')
end
else if(@isdoc is null)
begin
 set @flag=0;
 print('enter a type')
end
else
begin
 if(@isdoc=1)
 begin
  if exists(select * from doctor where DoctorID=@id)
  begin
   update doctor set Contact=@contact where DoctorID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('doctor not found')
  end
 end
 else
 begin
  if exists(select * from Patient where PatientID=@id)
  begin
   update Patient set Contact=@contact where PatientID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('patient not found')
  end
 end
end
end

go
create procedure editEmail
@id int,
@isdoc int,
@email varchar(32),
@flag int output
as begin
if(@email is null)
begin
 set @flag=0;
 print('enter a email')
end
else if(@id is null)
begin
 set @flag=0;
 print('enter an id')
end
else if(@isdoc is null)
begin
 set @flag=0;
 print('enter a type')
end
else if(@email not like '%@%.%')
begin
 print('Incorrect Email')
 set @flag=0
end
else
begin
 if(@isdoc=1)
 begin
  if exists(select * from doctor where DoctorID=@id)
  begin
   update doctor set Email=@email where DoctorID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('doctor not found')
  end
 end
 else
 begin
  if exists(select * from Patient where PatientID=@id)
  begin
   update Patient set Email=@email where PatientID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('patient not found')
  end
 end
end
end


go
create procedure editResidence
@id int,
@isdoc int,
@res nvarchar(200),
@flag int output
as begin
if(@res is null)
begin
 set @flag=0;
 print('enter a contact')
end
else if(@id is null)
begin
 set @flag=0;
 print('enter an id')
end
else if(@isdoc is null)
begin
 set @flag=0;
 print('enter a type')
end
else
begin
 if(@isdoc=1)
 begin
  if exists(select * from doctor where DoctorID=@id)
  begin
   update doctor set Residence=@res where DoctorID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('doctor not found')
  end
 end
 else
 begin
  if exists(select * from Patient where PatientID=@id)
  begin
   update Patient set Residence=@res where PatientID=@id
   set @flag=1
  end
  else
  begin
   set @flag=0
   print('patient not found')
  end
 end
end
end

go

create procedure getPatient
@id int,
@flag int output
as begin
if(@id is null)
begin
set @flag=0
end
else if not exists(select * from Patient where Patient.PatientID=@id)
begin
set @flag=0
end
else
begin
select Patient.PatientID, Patient.Name,Patient.Contact,Patient.Residence,Patient.Gender, Patient.DOB,Patient.Email
from Patient
where Patient.PatientID=@id
set @flag=1
end
end

go
--drop procedure docAvail 
create procedure docAvail
@docid int,
@flag int output
as begin
if(@docid is null)
begin
set @flag=0
end
else if not exists(select * from Doctor where DoctorID=@docid)
begin
set @flag=0
end
else
begin

set @flag=1
 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Available'
 from Doctor join DoctorsAvailibility on Doctor.DoctorID=DoctorsAvailibility.DoctorID
 where DoctorsAvailibility.DoctorID=@docid
 EXCEPT
 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Available'
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@docid

 order by DoctorsAvailibility.Date ASC

 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Booked'
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@docid
end
end

create procedure docAvail2
@docid int,
@flag int output
as begin
if(@docid is null)
begin
set @flag=0
end
else if not exists(select * from Doctor where DoctorID=@docid)
begin
set @flag=0
end
else
begin

set @flag=1 

 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Booked'
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@docid
 order by DoctorsAvailibility.Date ASC
end
end

declare @flagj int
exec docAvail
@docid=1,@flag=@flagj

select * from DoctorsAvailibility
select * from Appointments
go
--flag 0 is null entry,flag=1 if updated,flag=2 if repeat pass doesnot match,flag=3 if incorrect old password,flag=4 if id does not exists
create procedure editpassword1
@id int,
@isdoc int,
@oldpass varchar(32),
@pass2 varchar(32),
@pass varchar(32),
@flag int output
as begin
if(@oldpass is null)
begin
 set @flag=0;
 print('enter your previous password')
end
if(@pass is null)
begin
 set @flag=0;
 print('enter a new password')
end
if(@pass2 is null)
begin
 set @flag=0;
 print('Repeat your new password')
end
else if(@id is null)
begin
 set @flag=0;
 print('enter an id')
end
else if(@isdoc is null)
begin
 set @flag=0;
 print('enter a type')
end
else
begin
 if(@isdoc=1)
 begin
  if exists(select * from doctor where DoctorID=@id)
  begin
   if exists(select * from doctor where Doctor.[password]=@oldpass COLLATE SQL_Latin1_General_CP1_CS_AS)
   begin
   if( @pass=@pass2 COLLATE SQL_Latin1_General_CP1_CS_AS)
   begin
   print 'Password updated successfully!'
   update doctor set Doctor.[Password]=@pass  where DoctorID=@id
   set @flag=1
  end
  else 
  begin 
  print 'Password does not match'
  set @flag=2
  end
  end
  else 
  begin
  print 'Password does not match the previous password'
  set @flag=3
  end 
  end
  else
  begin
   set @flag=4
   print('doctor not found')
  end
 end
 else
 begin
 if exists(select * from patient where patientID=@id)
  begin
   if exists(select * from patient where patient.[password]=@oldpass COLLATE SQL_Latin1_General_CP1_CS_AS)
   begin
   if( @pass=@pass2 COLLATE SQL_Latin1_General_CP1_CS_AS)
   begin
   print 'Password updated successfully!'
   update patient set patient.[Password]=@pass where patientID=@id
   set @flag=1
  end
  else 
  begin 
  print 'Password does not match'
  set @flag=2
  end
  end
  else 
  begin
  print 'Password does not match the previous password'
  set @flag=3
  end 
  end
  else
  begin
   set @flag=4
   print('Patient not found')
  end
 end
 end
 end


declare @flagj int
exec editpassword1
@id=4,@isdoc=2,@oldpass='abC',@pass='hello',@pass2='hello',@flag=@flagj
select *from patient
go
--drop procedure cancelavalibility6 
create procedure cancelavalibility6
@docid int,
@availid int,
@flag int output
as begin
if exists(select *from doctor where Doctor.DoctorID=@docid)
begin
if exists(select *from DoctorsAvailibility where DoctorsAvailibility.AvailibilityID=@availid and DoctorsAvailibility.DoctorID=@docid)
begin
if exists(select *from Appointments where Appointments.AppointmentID=@availid )
begin
set @flag=1
print 'Appointment cancelled and email sent to patient!'
declare @body nvarchar(100)= 'Your appointment of Appointment id '+cast(@availid as nvarchar(20))+' has been cancelled by the doctor.Sorry for inconvenience' 
declare @email nvarchar(30)
select @email=patient.email
from Appointments join patient on Patient.PatientID=Appointments.PatientID
where Appointments.AppointmentID=@availid
EXEC msdb.dbo.sp_send_dbmail  
@profile_name ='Doctors Hub',  
@recipients = @email,  
@subject = 'Appointment Cancelation',  
@body = @body,
@importance='HIGH'
end
else 
begin 
print 'No appoinment taken by any patient'
set @flag=2
end
begin
print 'Availibility cancelled'
delete from DoctorsAvailibility
where DoctorsAvailibility.AvailibilityID=@availid
end
end 
else
begin
print 'No such availibility exists'
set @flag=0
end
end
else 
begin
print 'No such doctor exists'
end
end
go

declare @flagj int
exec cancelavalibility6
@docid=1,@availid=14,@flag=@flagj

select *from DoctorsAvailibility
select *from Appointments
insert into DoctorsAvailibility values
(9,3,'01-01-2001','1:1')


--procedure for doctor patient--28
go
create procedure messagesreply2
@docid int,
@patid int,
@comment nvarchar(500),
@flag int output
as begin
if exists(select *from doctor where Doctor.DoctorID=@docid)
begin
if exists(select*from patient where patient.PatientID=@patid)
begin 
if exists(select * from messagereply where messagereply.doctorid=@docid and messagereply.patientid=@patid)
begin
set @flag=3
print 'Previous messages deleted'
delete 
from messagereply 
where messagereply.DoctorID=@docid and messagereply.PatientID=@patid
end
else
begin
set @flag=2
print 'Message sent!'
insert into messagereply values(@patid,@docid,@comment)
end
end
else
begin
set @flag=0
print 'No such patient id exists'
end
end
else
begin
set @flag=1
print 'No such doctor id exists'
end
end


declare @flagj int
exec messagesreply2
@docid=2,@patid=6,@comment='hello how are you?',@flag=@flagj
select *from Patient
select*from Doctor
select *from messagereply


go
create procedure sendmail3
as begin
exec msdb.dbo.sp_send_dbmail
@profile_name='Doctors Hub'
,@recipients='l182115@lhr.nu.edu.pk'
,@subject=' '
,@body='xyz
'
,@importance='HIGH'
end





insert into Doctor values 
(10,'d1','111','a','M','01-01-2001','p@a.com',10,'abc')

go
create procedure temp
as begin
delete from doctor where doctorid=8
end

go
--drop procedure reminder11
create procedure reminder11
 as begin
 if exists(select * from Reminder where CONVERT(Date, GETDATE())>=reminder.date and CONVERT(TIME, GETDATE())>=reminder.time)--and CONVERT(TIME, GETDATE())>=reminder.time)
 begin
 declare @description nvarchar(100)
 declare @date date
 declare @time time
 select @description=description, @date=date,@time=time from reminder where CONVERT(Date, GETDATE())>=reminder.date and CONVERT(TIME, GETDATE())>=reminder.time
 declare @body nvarchar(100)= 'You have a reminder of ' +cast(@description as varchar(50))+'!' 
declare @email nvarchar(30)
select @email=patient.email
from reminder join patient on Patient.PatientID=reminder.PatientID
where reminder.patientid=patient.patientid
--select @email
EXEC msdb.dbo.sp_send_dbmail  
@profile_name = 'Doctors Hub',  
@recipients = @email,  


@subject = 'Medicine Reminder',  
@body = @body,
@importance='HIGH'
 
 delete from Reminder
 where convert(date,getdate())>=@date and convert(time,getdate())>=@time
 end
 end
 go

 exec reminder11
 select * from reminder

----------------------------------------------------------------------------------------------------- 

drop table messagereply
create table messagereply(
messageid int,
PatientID int,
DoctorID int,
isdoc int,
Comment nvarchar(500)
);

Alter Table messagereply alter column messageID int NOT NULL
Alter Table messagereply alter column DoctorID int NOT NULL
Alter Table messagereply alter column PatientID int NOT NULL
Alter Table messagereply alter column isdoc int NOT NULL
Alter Table messagereply alter column Comment nvarchar(500) NOT NULL


Alter Table messagereply add constraint UNIQUE_CONSTRAINT_messagereply primary key  (messageid,PatientID,DoctorID) 


Alter Table messagereply add constraint FK_M foreign key (PatientID) references Patient (PatientID) on delete cascade
Alter Table messagereply add constraint FK_M2 foreign key (DoctorID) references Doctor (DoctorID) on delete cascade

go

insert into messagereply values
(1,2,1,'hello'),
(2,1,3,'abc')
go

create procedure messagesreply7
@docid int,
@patid int,
@comment nvarchar(500),
@flag int output
as begin
if(@patid is NULL)
begin
print('Enter a patientid!')
set @flag=2
end
if(@docid is NULL)
begin
print('Enter a doctorid!')
set @flag=3
end
if exists(select *from doctor where Doctor.DoctorID=@docid)
begin
if exists(select*from patient where patient.PatientID=@patid)
begin 
if(@comment is NULL)
begin
print('Write a message!')
set @flag=4
end
else
set @flag=2
print 'Message sent!'
if exists (select * from  messagereply)
begin
insert into messagereply values((select max( messagereply.messageid)+1 from messagereply),@patid,@docid,@comment)
set @flag=1
end
else
begin
 insert into messagereply values(1,@patid,@docid,@comment)
   end
  end
else
begin
set @flag=0
print 'No such patient id exists'
set @flag=5
end
end
else
begin
set @flag=1
print 'No such doctor id exists'
set @flag=6
end
end

go
--drop procedure todayappoin
create procedure todayappoin
as begin
if exists(select * from Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID where  datediff(day,getdate(), DoctorsAvailibility.Date)=1)
begin
declare @appointment int
select @appointment=Appointments.AppointmentID from Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID where  datediff(day,getdate(), DoctorsAvailibility.Date)=1
declare @body nvarchar(100)= 'Your appointment of Appointment id '+cast(@appointment as nvarchar(20))+' is scheduled tomorrow.' 
			declare @email nvarchar(30)
			select @email=patient.email
			from Appointments join patient on Patient.PatientID=Appointments.PatientID
			where Appointments.AppointmentID=@appointment
			select @email
			EXEC msdb.dbo.sp_send_dbmail  
			@profile_name = 'Doctors Hub',  
			@recipients = @email,  
			@subject = 'Appointment Reminder',  
			@body = @body,
			@importance='HIGH'
end
end

exec todayappoin

drop trigger book
use doctorshub
create trigger book
on appointments
after insert
as begin
declare @patient int,
@availibility int
select @patient=inserted.patientid, @availibility=inserted.AppointmentID
from inserted
if exists(select * from appointments where @patient=appointments.patientid and  @availibility=appointments.AppointmentID)
 begin
  declare @body nvarchar(100)= 'Your appointment has been booked with Appointment id ' +cast(@availibility as varchar(50))+'!' 
declare @email nvarchar(30)
select @email=patient.email
from Appointments join patient on Patient.PatientID=Appointments.PatientID
where Appointments.AppointmentID=@availibility
select @email
EXEC msdb.dbo.sp_send_dbmail  
@profile_name ='Doctors Hub',  
@recipients = @email,  
@subject = 'Appointment',  
@body = @body,
@importance='HIGH'
 --print('Your appoinment has been booked')
 end
 end
 go

 


 select * from Appointments

declare @appointment int
			set @appointment=6
			delete from appointments where AppointmentID = @appointment
			declare @body nvarchar(100)= 'Your appointment of Appointment id '+cast(@appointment as nvarchar(20))+' has been cancelled and is given to patient who was waiting.' 
			declare @email varchar(30)
			select *--@email=patient.email
			from Appointments join patient on Patient.PatientID=Appointments.PatientID
			where Appointments.AppointmentID=6
			select @email
			EXEC msdb.dbo.sp_send_dbmail  
			@profile_name = 'Doctors Hub',  
			@recipients = @email,  
			@subject = 'Appointment Cancelation',  
			@body = @body,
			@importance='HIGH'

select * from Reminder

create procedure messagesreply3
@docid int,
@patid int,
@isdoc int,
@comment nvarchar(500),
@flag int output
as begin
if exists(select*from Doctor where doctor.DoctorID=@docid) --doctor
begin
 if(@patid is NULL)
 begin
  print('Enter a patientid!')
  set @flag=2
 end
 else if exists(select*from patient where patient.PatientID=@patid)
 begin 
  if(@comment is NULL)
  begin
   print('Write a message!')
   set @flag=4
  end
  else
   set @flag=2
   print 'Message sent!'
   if exists (select * from  messagereply where PatientID=@patid and DoctorID=@docid)
   begin
    declare @count int
    insert into messagereply values((select count( messagereply.messageid)+1 from messagereply where messagereply.patientid=@patid and messagereply.doctorid=@docid),@patid,@docid,@isdoc,@comment)
    set @flag=1
   end
   else
   begin
    insert into messagereply values(1,@patid,@docid,@isdoc,@comment)--??
   end
 end
 else
 begin
  set @flag=0
  print 'No such patient id exists'
 end
end
else
begin
 set @flag=5
 print 'No such Doctor id exists'
end
end

declare @flagj int
exec messagesreply3
@docid=2,@patid=1,@isdoc=1,@comment='i am fine how are you?',
@flag=@flagj output
select *from Patient
select*from Doctor
select *from messagereply

drop procedure allavailibilityA

CREATE PROCEDURE allavailibilityA
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
IF EXISTS (SELECT DoctorsAvailibility.DoctorID FROM DoctorsAvailibility WHERE DoctorsAvailibility.DoctorID =@doctorid)
begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has availibility:'
 set @flag=1
 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Available'
 from Doctor join DoctorsAvailibility on Doctor.DoctorID=DoctorsAvailibility.DoctorID
 where DoctorsAvailibility.DoctorID=@doctorid
 EXCEPT
 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Available'
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@doctorid

 order by DoctorsAvailibility.Date ASC

 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time, Status='Booked'
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@doctorid
End
 else
  print 'Doctor is not available!'
 set @flag=2
 end
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go

CREATE PROCEDURE allavailibilityB
@doctorid int,@flag int output
AS BEGIN
IF EXISTS (SELECT Doctor.DoctorID FROM [Doctor] WHERE Doctor.DoctorID =@doctorid)
Begin
IF EXISTS (SELECT DoctorsAvailibility.DoctorID FROM DoctorsAvailibility WHERE DoctorsAvailibility.DoctorID =@doctorid)
begin
 print'Doctor with doctor Id'+ cast(@doctorid as varchar(11))+ 'has availibility:'
 set @flag=1

 select DoctorsAvailibility.AvailibilityID,DoctorsAvailibility.Date,DoctorsAvailibility.Time
 from (Appointments join DoctorsAvailibility on Appointments.AppointmentID=DoctorsAvailibility.AvailibilityID)join Doctor on DoctorsAvailibility.DoctorID=Doctor.DoctorID
 where DoctorsAvailibility.DoctorID=@doctorid

 order by DoctorsAvailibility.Date ASC
End
 else
  print 'Doctor is not available!'
 set @flag=2
 end
else
Begin
 print 'Doctor not found!'
 set @flag=0
End
End
go

select * from DoctorsAvailibility
select * from Appointments

declare @flagt int
exec allavailibilityA
@doctorid=1,@flag=@flagt output


select Doctor.DoctorID, Status='available'
from Doctor

go
create procedure idmeaasge
@id int,
@isdoc int,
@flag int output
as begin
if(@isdoc=0)
begin
 select m.DoctorID,Doctor.Name,m.Comment
 from (messagereply as m join doctor on m.doctorid=doctor.doctorid)
 where m.PatientID=@id and m.messageid in (select max(messagereply.messageid)
                                           from messagereply
										   where messagereply.PatientID=@id and messagereply.DoctorID=m.DoctorID
										   )
end
else
begin
 select m.PatientID,Patient.Name,m.Comment
 from messagereply as m join Patient on m.PatientID=Patient.PatientID
 where m.DoctorID=@id and m.messageid in (select max(messagereply.messageid)
                                           from messagereply
										   where messagereply.DoctorID=@id and messagereply.PatientID=m.PatientID
										   )
end
end


declare @flagj int
exec messagesreply3
@docid=1,@patid=2,@isdoc=0,@comment='d1p2?',
@flag=@flagj output

select * from messagereply

declare @flagj1 int
exec idmeaasge
@id=1,@isdoc=1,
@flag=@flagj1 output

go
create procedure searchchat
@pid int,
@did int,
@isdoc int,
@flag int output
as begin
if not exists(select * from Patient where Patient.PatientID=@pid)
begin
 set @flag=0
end
else if not exists(select * from Doctor where Doctor.DoctorID=@did)
begin
 set @flag=1
end
else
begin
 if exists(select * from messagereply where messagereply.PatientID=@pid and messagereply.DoctorID=@did)
 begin
  set @flag=2
  if(@isdoc=1)
  begin
   select m.PatientID,Patient.Name,m.Comment
   from messagereply as m join Patient on m.PatientID=Patient.PatientID
   where m.DoctorID=@did and m.PatientID=@pid and m.messageid in (select max(messagereply.messageid)
																  from messagereply
																  where messagereply.DoctorID=@did and messagereply.PatientID=@pid
										                          )
  end
  else
  begin
   select m.DoctorID,Doctor.Name,m.Comment
   from messagereply as m join Doctor on m.DoctorID=Doctor.DoctorID
   where m.DoctorID=@did and m.PatientID=@pid and m.messageid in (select max(messagereply.messageid)
																  from messagereply
																  where messagereply.DoctorID=@did and messagereply.PatientID=@pid
										                          )
  end
 end
 else
 begin
  set @flag=4
  if(@isdoc=1)
  begin
   select Patient.PatientID,Patient.Name,Comment=' '
   from Patient
   where Patient.PatientID=@pid
  end
  else
  begin
   select Doctor.DoctorID,Doctor.Name,Comment=' '
   from Doctor
   where Doctor.DoctorID=@did
  end
 end
end
end

go
create procedure mychat
@pid int,
@did int,
@flag int output
as begin
if not exists(select * from Patient where Patient.PatientID=@pid)
begin
 set @flag=0
end
else if not exists(select * from Doctor where Doctor.DoctorID=@did)
begin
 set @flag=1
end
else
begin
 select messagereply.messageid,messagereply.PatientID,messagereply.DoctorID,messagereply.isdoc,messagereply.Comment
 from messagereply
 where messagereply.PatientID=@pid and messagereply.DoctorID=@did
 order by messagereply.messageid asc
end
end

declare @flagj2 int
exec searchchat
@pid=1,@did=1,@isdoc=0,
@flag=@flagj2 output


select * from messagereply