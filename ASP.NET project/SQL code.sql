
/*

-- За да може български текст в талбиците(bulgarian text in the tables... change collation)
-- Right click on database name->Properties->Options->Collation: Cyrillic_General_CL_AS

*/

use [ASP programming]
go

create table RoboSimulations(
id int identity constraint pk_RoboSimulations primary key not null,
simulation_name nvarchar(64) not null,
simulation_owner nvarchar(64) not null,
simulation_owner_email nvarchar(32) not null,
simulation_description nvarchar(1024) not null,
simulation_rating decimal(16,2) constraint ck_simulation_rating CHECK (simulation_rating >= 0.0 AND simulation_rating <= 6.0),
)
go

--drop table RoboSimulations
go

create table Environments(
id int identity constraint pk_Environments primary key not null,
name nvarchar(32) not null,
travel_cost_enter decimal(16,2) constraint ck_cost_enter CHECK (travel_cost_enter >= 0.0) not null,
travel_cost_in decimal(16,2) constraint ck_cost_in CHECK (travel_cost_in >= 0.0) not null,
travel_cost_exit decimal(16,2) constraint ck_cost_exit CHECK (travel_cost_exit >= 0.0),
damage decimal(16,2) constraint ck_damage CHECK (damage >= 0.0) not null,
)
go

--drop table Environments


create table RoboSimulationsToEnvironments(
robo_simulation_id int not null,
environment_id int not null,
constraint pk_RoboSimulationsToEnvironments primary key(robo_simulation_id, environment_id),
constraint fk_RoboSimulationsToEnvironments_RoboSimulations foreign key (robo_simulation_id) references RoboSimulations(id) on delete cascade,
constraint fk_RoboSimulationsToEnvironments_Environments foreign key (environment_id) references Environments(id) on delete cascade
)
go

--drop table RoboSimulationsToEnvironments



create table Robots(
id int identity constraint pk_Robos primary key not null,
name nvarchar(64) not null,
owner nvarchar(64) not null,
robot_mesh_grid nvarchar(32) not null,
speed decimal(16,2) constraint ck_speed CHECK (speed >= 0.0) not null,
speed_back decimal(16,2) constraint ck_speed_back CHECK (speed_back >= 0.0) not null,
turning_speed decimal(16,2) constraint ck_turning_speed CHECK (turning_speed >= 0.0) not null,
turning_speed_back decimal(16,2) constraint ck_turning_speed_back CHECK (turning_speed_back >= 0.0) not null,
)
go

--drop table Robots


create table RoboSimulationsToRobots(
robo_simulation_id int not null,
robot_id int not null,
constraint pk_RoboSimulationsToRobots primary key(robo_simulation_id, robot_id),
constraint fk_RoboSimulationsToRobots_RoboSimulations foreign key (robo_simulation_id) references RoboSimulations(id) on delete cascade,
constraint fk_RoboSimulationsToRobots_Robots foreign key (robot_id) references Robots(id) on delete cascade
)
go

--drop table RoboSimulationsToRobots


create table Wheels(
id int identity constraint pk_Wheels primary key not null,
driving nvarchar(2) constraint ck_wheel_driving CHECK (driving = 'ДА' or driving = 'НЕ') not null,
wheel_mesh_grid nvarchar(32) not null,
wheel_diameter decimal(16,2) constraint ck_wheel_diameter CHECK (wheel_diameter >= 0.0) not null,
wheel_width decimal(16,2) constraint ch_wheel_width CHECK (wheel_width >= 0.0) not null,
)
go
--drop table Wheels

/*
insert into Wheels (driving, wheel_mesh_grid, wheel_diameter, wheel_width)
values ('НЕ', 'асд', 10.32, 1203.322)

select * from Wheels

*/



create table RobotsToWheels(
robot_id int not null,
wheel_id int not null,
constraint pk_RobotsToWheels primary key(robot_id, wheel_id),
constraint fk_RobotsToWheels_Robots foreign key (robot_id) references Robots(id) on delete cascade,
constraint fk_RobotsToWheels_Wheels foreign key (wheel_id) references Wheels(id) on delete cascade
)
go
--drop table RobotsToWheels


create table Sensors(
id int identity constraint pk_Sensors primary key not null,
name nvarchar(128) not null,
value_type nvarchar(32) not null,
sensor_mesh_grid nvarchar(32) not null,
number_of_values_per_second decimal(8,2) constraint ck_number_of_values_per_second CHECK (number_of_values_per_second >= 0.0) not null,
)
go
--drop table Sensors

create table RobotsToSensors(
robot_id int not null,
sensor_id int not null,
constraint pk_RobotsToSensors primary key(robot_id, sensor_id),
constraint fk_RobotsToSensors_Robots foreign key (robot_id) references Robots(id) on delete cascade,
constraint fk_RobotsToSensors_Sensors foreign key (sensor_id) references Sensors(id) on delete cascade
)
go
--drop table RobotsToSensors

create table Rotors(
id int identity constraint pk_Rotors primary key not null,
rotor_mesh_grid nvarchar(32) not null,
rotor_lifting_power decimal(16,2) constraint ck_rotor_lifting_power CHECK (rotor_lifting_power >= 0.0) not null,
)
go
--drop table Rotors

create table RobotsToRotors(
robot_id int not null,
rotor_id int not null,
constraint pk_RobotsToRotors primary key(robot_id, rotor_id),
constraint fk_RobotsToRotors_Robots foreign key (robot_id) references Robots(id) on delete cascade,
constraint fk_RobotsToRotors_Rotors foreign key (rotor_id) references Rotors(id) on delete cascade
)
go
--drop table RobotsToRotors


-- Which robot which environments can walk through
--create table RobotsToEnvironments(
--robot_id int not null,
--environment_id int not null,
--constraint pk_RobotsToEnvironments primary key(robot_id, environment_id),
--constraint fk_RobotsToEnvironments_Robots foreign key (robot_id) references Robots(id) on delete cascade,
--constraint fk_RobotsToEnvironments_Environments foreign key (environment_id) references Environments(id) on delete cascade
--)
--go
--drop table RobotsToEnvironments



create table Maps(
id int identity constraint pk_Maps primary key not null,
map_data nvarchar(64) not null,
map_name nvarchar(64) not null,
denivelation decimal(16,2) not null,
)
go
--drop table Maps



-- Which map which environments have
--create table MapsToEnvironments(
--map_id int not null,
--environment_id int not null,
--constraint pk_MapsToEnvironments primary key(map_id, environment_id),
--constraint fk_MapsToEnvironments_Maps foreign key (map_id) references Maps(id) on delete cascade,
--constraint fk_MapsToEnvironments_Environments foreign key (environment_id) references Environments(id) on delete cascade
--)
--go
--drop table MapsToEnvironments


create table RoboSimulationsToMaps(
robo_simulation_id int not null,
map_id int not null,
constraint pk_RoboSimulationsToMaps primary key(robo_simulation_id, map_id),
constraint fk_RoboSimulationsToMaps_RoboSimulations foreign key (robo_simulation_id) references RoboSimulations(id) on delete cascade,
constraint fk_RoboSimulationsToMaps_Maps foreign key (map_id) references Maps(id) on delete cascade
)
go

--drop table RoboSimulationsToMaps

create table Algorithms(
id int identity constraint pk_Algorithms primary key not null,
name nvarchar(64) not null,
diffEnvironments nvarchar(2) constraint ck_algorithm_diffEnvironments CHECK (diffEnvironments = 'ДА' or diffEnvironments = 'НЕ') not null,
multipleDestPoints nvarchar(2) constraint ck_algorithm_multipleDestPoints CHECK (multipleDestPoints = 'ДА' or multipleDestPoints = 'НЕ') not null,
complexity nvarchar(32) not null,
depth nvarchar(32) not null,
)
go
--drop table Algorithms


create table RoboSimulationsToAlgorithms(
robo_simulation_id int not null,
algorithm_id int not null,
constraint pk_RoboSimulationsToAlgorithms primary key(robo_simulation_id, algorithm_id),
constraint fk_RoboSimulationsToAlgorithms_RoboSimulations foreign key (robo_simulation_id) references RoboSimulations(id) on delete cascade,
constraint fk_RoboSimulationsToAlgorithms_Algorithms foreign key (algorithm_id) references Algorithms(id) on delete cascade
)
go
--drop table RoboSimulationsToAlgorithms

/*
-- All my tables

drop table RobotsToRotors
drop table RobotsToSensors
drop table RobotsToWheels
--drop table RobotsToEnvironments
drop table Rotors
drop table Sensors
drop table Wheels

--drop table MapsToEnvironments

drop table RoboSimulationsToEnvironments
drop table RoboSimulationsToRobots
drop table RoboSimulationsToMaps
drop table RoboSimulationsToAlgorithms

drop table Environments
drop table Robots
drop table Maps
drop table Algorithms
drop table RoboSimulations

*/


/*
insert into 

insert into Wheels (driving, wheel_mesh_grid, wheel_diameter, wheel_width)
values ('НЕ', 'асд', 10.32, 1203.322)

insert into RoboSimulations (simulation_name, simulation_owner, simulation_owner_email)
values ('Симулация 1', 'Тони', 'anton@gmail.com')

insert into RoboSimulations (simulation_name, simulation_owner, simulation_owner_email)
values ('Симулация 2', 'Тони2', 'anton@gmail.com2')

insert into RoboSimulations (simulation_name, simulation_owner, simulation_owner_email)
values ('Симулация 3', 'Тони3', 'anton@gmail.com3')

select * from Wheels
select * from RoboSimulations


*/