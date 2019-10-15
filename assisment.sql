--1
select account_number, c.customer_number, firstname, lastname,account_opening_date from
customer_master c inner join
account_master
on c.customer_number=account_master.customer_number

--2
select count(customer_city) as cust_count from customer_master where customer_city='DELHI'

--3
select c.customer_number, firstname, account_number from 
customer_master c inner join
account_master a
on c.customer_number=a.customer_number
where Day(a.account_opening_date)>'15'
order by c.customer_number asc

select c.customer_number, firstname, account_number from 
customer_master c inner join
account_master a
on c.customer_number=a.customer_number
where Day(a.account_opening_date)>'15'
order by account_number asc


--4

select c.customer_number, firstname, account_number from 
customer_master c inner join
account_master a
on c.customer_number=a.customer_number
where a.account_status = 'terminated'
order by account_number asc

select c.customer_number, firstname, account_number from 
customer_master c inner join
account_master a
on c.customer_number=a.customer_number
where a.account_status = 'terminated'
order by customer_number asc

--5
select transaction_type,count(transaction_number) as Trans_Count
from account_master a inner join transaction_details t
on a.account_number=t.account_number
where customer_number like '%1'
group by transaction_type
order by transaction_type


---6
select count(customer_number) as Count_Customer
from customer_master
where customer_number not in (select customer_number from account_master)

--7

select t.account_number,a.opening_balance+sum(transaction_amount) as deposit_amount
from account_master a inner join transaction_details t
on a.account_number=t.account_number
where transaction_type='DEPOSIT'
group by t.account_number,a.opening_balance
order by t.account_number
