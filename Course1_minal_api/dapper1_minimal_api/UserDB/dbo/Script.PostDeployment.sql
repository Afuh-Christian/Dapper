if not exists (select 1 from dbo.[User]) 
begin 
  insert into dbo.[User] (FirstName , LastName) 
  values ('Tim' , 'Corry' ), 
  ('Afuh' , 'christian') , 
  ('Anyangwe' , 'duke'),
  ('Tanlaka' , 'Nji');
end