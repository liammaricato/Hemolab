create database Hemolab;
use Hemolab;

create table Tipo_Fracionamento 
(
    cd_tipo_fracionamento int not null,
    nm_tipo_fracionamento varchar(65) not null,
    constraint pk_tipo_fracionamento primary key (cd_tipo_fracionamento)
);

create table Tipo_Sanguineo 
(
    cd_tipo_sanguineo int not null,
    nm_tipo_sanguineo varchar(45) not null,
    constraint pk_tipo_sanguineo primary key (cd_tipo_sanguineo)
);

create table Situacao_Bolsa 
(
    cd_situacao_bolsa int not null,
    nm_situacao_bolsa varchar(60),
    constraint pk_situacao_bolsa primary key (cd_situacao_bolsa)
);

create table Tipo_Exame 
(
    cd_tipo_exame int not null,
    nm_tipo_exame varchar(65) not null,
    constraint pk_tipo_exame primary key (cd_tipo_exame)
);

create table Tipo_Funcionario 
(
    cd_tipo_funcionario int not null,
    nm_tipo_funcionario varchar(65) not null,
    constraint pk_tipo_funcionario primary key (cd_tipo_funcionario)
);

create table Funcionario 
(
    cd_funcionario int not null,
    cd_tipo_funcionario int not null,
    nm_funcionario varchar(100) not null,
    cd_cpf_funcionario varchar(65),
    cd_senha_funcionario varchar(65),
    constraint pk_funcionario primary key (cd_funcionario),
    constraint fk_funcionario_tipo_funcionario foreign key (cd_tipo_funcionario)
        References Tipo_Funcionario (cd_tipo_funcionario)
);

create table Doador 
(
    cd_rg_doador varchar(13) not null,
    cd_cpf_doador varchar(15) not null,
    cd_funcionario int not null,
    nm_doador varchar(100) not null,
    sg_sexo_doador varchar(4) not null,
    dt_nascimento_doador date not null,
    nm_email_doador varchar(70) not null,
    cd_telefone_residencial_doador varchar(15) not null,
    cd_telefone_celular_doador varchar(15) null,
    constraint pk_doador primary key (cd_rg_doador),
    constraint fk_doador_funcionario foreign key (cd_funcionario)
        References Funcionario (cd_funcionario)
);

create table Triagem 
(
    cd_rg_doador varchar(13) not null,
    cd_triagem int not null,
    cd_funcionario int not null,
    dt_triagem date not null,
    hr_triagem time not null,
    qt_quilos_doador decimal(10 , 2 ) null,
    qt_pressao_doador varchar(10) null,
    qt_temperatura_doador decimal(10 , 2 ) null,
    qt_bpm_doador int null,
    qt_hemoglobina_doador decimal(10 , 2 ) null,
    qt_hematocrito_doador int null,
    ic_pre_triagem_doador bool null,
    ic_triagem_doador bool null,
    constraint pk_triagem primary key (cd_rg_doador , cd_triagem),
    constraint fk_triagem_doador foreign key (cd_rg_doador)
        References Doador (cd_rg_doador),
    constraint fk_triagem_funcionario foreign key (cd_funcionario)
        References Funcionario (cd_funcionario)
);

create table Bolsa_Coletada 
(
    dt_coleta date not null,
    cd_rg_doador varchar(13) not null,
    cd_tipo_sanguineo int null,
    cd_funcionario int not null,
    cd_bolsa_coletada varchar(13) not null,
    dt_descarte_bolsa date null,
    hr_coleta time null,
    ic_coleta_sem_sucesso bool null,
    ic_mandou_email bool null,
    constraint pk_bolsa_coletada primary key (dt_coleta , cd_rg_doador),
    constraint fk_bolsa_coletada_tipo_sanguineo foreign key (cd_tipo_sanguineo)
        references Tipo_Sanguineo (cd_tipo_sanguineo),
    constraint fk_bolsa_coletada_doador foreign key (cd_rg_doador)
        references Doador (cd_rg_doador),
    constraint fk_bolsa_coletada_funcionario foreign key (cd_funcionario)
        References Funcionario (cd_funcionario)
);

create table Exame 
(
    dt_coleta date not null,
    cd_rg_doador varchar(13) not null,
    cd_tipo_exame int not null,
    cd_funcionario int not null,
    dt_exame date not null,
    ic_resultado_exame bool null,
    constraint pk_exame primary key (dt_coleta , cd_rg_doador , cd_tipo_exame),
    constraint fk_exame_bolsa_coletada foreign key (dt_coleta , cd_rg_doador)
        References Bolsa_Coletada (dt_coleta , cd_rg_doador),
    constraint fk_exame_funcionario foreign key (cd_funcionario)
        References Funcionario (cd_funcionario)
);

create table Bolsa_Fracionada 
(
    dt_coleta date not null,
    cd_rg_doador varchar(13) not null,
    cd_tipo_fracionamento int not null,
    cd_bolsa_fracionada varchar(14) not null,
    qt_gramas_bolsa_fracionada int not null,
    constraint pk_bolsa_fracionada primary key (dt_coleta , cd_rg_doador , cd_tipo_fracionamento),
    constraint fk_bolsa_fracionada_bolsa_coletada foreign key (dt_coleta , cd_rg_doador)
        references Bolsa_Coletada (dt_coleta , cd_rg_doador)
);

create table Ocorrencia_Situacao_Bolsa 
(
    dt_ocorrencia date not null,
    hr_ocorrencia time not null,
    cd_situacao_bolsa int not null,
    dt_coleta date not null,
    cd_rg_doador varchar(13) not null,
    cd_tipo_fracionamento int not null,
    cd_funcionario int not null,
    ic_procedimento_realizado bool not null,
    constraint pk_ocorrencia_situacao_bolsa primary key (dt_ocorrencia , hr_ocorrencia , cd_situacao_bolsa , dt_coleta , cd_rg_doador , cd_tipo_fracionamento),
    constraint fk_ocorrencia_situacao_bolsa_situacao_bolsa foreign key (cd_situacao_bolsa)
        references Situacao_Bolsa (cd_situacao_bolsa),
    constraint fk_ocorrencia_situacao_bolsa_bolsa_fracionada foreign key (dt_coleta , cd_rg_doador , cd_tipo_fracionamento)
        references Bolsa_Fracionada (dt_coleta , cd_rg_doador , cd_tipo_fracionamento),
    constraint fk_ocorrencia_situacao_bolsa_funcionario foreign key (cd_funcionario)
        References Funcionario (cd_funcionario)
);

insert into Tipo_Fracionamento
values -- (cd_tipo_fracionamento, sg_tipo_fracionamento, nm_tipo_fracionamento)
(1, 'Concentrado de Hemácias'),
(2, 'Plasma Fresco Congelado'),
(3, 'Concentrado de Plaquetas'),
(4, 'Crioprecipitado');

insert into Tipo_Sanguineo
values -- (cd_tipo_sanguineo, nm_tipo_sanguineo)
(1, 'O-'),
(2, 'O+'),
(3, 'A-'),
(4, 'A+'),
(5, 'B-'),
(6, 'B+'),
(7, 'AB-'),
(8, 'AB+');

insert into Situacao_Bolsa
values -- (cd_situacao, nm_situacao)
(1, 'Armazenada'),
(2, 'Levada para Transfusão'),
(3, 'Passou da Validade');

insert into Tipo_Exame
values -- (cd_tipo_exame, nm_tipo_exame)
(1, 'Hepatite B'),
(2, 'Hepatite C'),
(3, 'Vírus de Linfócitos'),
(4, 'Doença de Chagas'),
(5, 'Sífilis'),
(6, 'HIV');

insert into Tipo_Funcionario
values -- (cd_tipo_funcionario, nm_tipo_funcionario)
(1, 'Administrador'),
(2, 'Recepção'),
(3, 'Pré-Triagem'),
(4, 'Triagem'),
(5, 'Sala de Coleta'),
(6, 'Sorologia'),
(7, 'Imuno-Hematologia'),
(8, 'Fracionamento'),
(9, 'Estoque'),
(10, 'Distribuição');

insert into Funcionario
values -- (cd_funcionario, cd_tipo_funcionario, nm_funcionario, cd_cpf_funcionario, cd_senha_funcionario)
(123, 1, 'admin', '123.456.789-10', md5('123')),
(1, 1, 'João Silva', '789.456.123-11', md5('123')),
(2, 2, 'Fernando Paulo', '492.930.549-02', md5('123')),
(3, 3, 'Ana Beatriz', '365.284.980-90', md5('123')),
(4, 4, 'Jamir Júnior', '365.284.980-90', md5('123')),
(5, 5, 'Pedro Fernandes', '213.536.836-53', md5('123')),
(6, 6, 'Lucas Paulo', '763.983.135-75', md5('123')),
(7, 7, 'Maria Carla', '435.536.536-34', md5('123')),
(8, 8, 'Rafael Ferreira', '533.565.254-97', md5('123')),
(9, 9, 'Clara Lima', '596.064.472-59', md5('123')),
(10, 10, 'Beatriz Araújo', '538.642.798-23', md5('123'));

insert into Doador
values -- (cd_rg_doador, cd_cpf_doador, cd_funcionario, nm_doador, sg_sexo_doador, dt_nascimento_doador, nm_email_doador, 
	   -- cd_telefone_residencial_doador, cd_telefone_celular_doador, cd_telefone_alternativo_doador)
('38.429.472-8', '123.456.789-00', 002, 'Pedro Ferreira', 'Masc', '1963-08-23',
 'gustavomatosaraujo@hotmail.com', '1732458691', '17981527943'),
('46.539.109-6', '738.275.823-90', 002, 'Joaquim Pereira', 'Masc', '1985-03-12',
 'liammaricato@gmail.com', '1133245465', '11981294093'),
('37.651.603-3', '440.308.938-05', 123, 'Liam Maricato', 'Masc', '1998-07-01',
 'liammaricato@gmail.com', '1133245465', '11981294093'),
('40.242.805-5', '400.300.200-12', 002, 'Maria Rafaela', 'Fem', '1978-12-02',
 'gustavomatosaraujo@hotmail.com', '1323909430', '13994300102'),
('17.409.098-5', '440.308.938-05', 002, 'Carlos Alberto', 'Masc', '1977-11-21',
 'liammaricato@gmail.com', '1133245465', '11981294093'),
('23.124.880-5', '440.308.938-05', 002, 'Laura Oliveira', 'Fem', '1982-03-17',
 'gustavomatosaraujo@hotmail.com', '1133245465', '11981294093');

insert into Triagem
values -- (cd_cpf_doador, cd_triagem, cd_funcionario, dt_triagem, hr_triagem, qt_quilos_doador, qt_pressao_doador, 
	   -- qt_temperatura_doador, qt_bpm_doador, qt_hemoglobina_doador, qt_hematocrito_doador, ic_triagem_doador)
('38.429.472-8', 1, 003, '2016-04-15', '12:00:00', 72.5, '130/90', 36.2, 73, 13.0, 40, true, true),
('46.539.109-6', 1, 003, '2015-03-25', '13:00:00', null, null, null, null, null, null, null, null),
('37.651.603-3', 1, 003, '2015-03-25', '14:00:00', 68.8, '120/80', 36.5, 80, 20.0, 40, true, true),
('40.242.805-5', 1, 003, '2016-02-03', '14:00:00', 68.8, '120/80', 36.5, 80, 20.0, 40, true, true),
('17.409.098-5', 1, 003, '2016-03-27', '14:00:00', 68.8, '120/80', 36.5, 80, 20.0, 40, true, true),
('23.124.880-5', 1, 003, '2016-05-12', '14:00:00', 68.8, '120/80', 36.5, 80, 20.0, 40, true, true);

insert into Bolsa_Coletada
values -- (dt_coleta, cd_rg_doador, cd_tipo_sanguineo, cd_funcionario, cd_bolsa_coletada, dt_descarte_bolsa,
	   -- hr_coleta, ic_coleta_sem_sucesso)
('2016-04-15', '38.429.472-8', 1, 004, '3842947281', null, '12:43:00', false, false),
('2015-03-25', '37.651.603-3', 2, 004, '3765160331', null, '19:22:00', false, false),
('2016-02-03', '40.242.805-5', 3, 004, '4024280551', null, '08:30:00', false, false),
('2016-03-27', '17.409.098-5', 4, 004, '1740909851', null, '12:43:00', false, false),
('2016-05-12', '23.124.880-5', 5, 004, '2312488051', null, '12:43:00', false, false);

insert into Exame
values -- (dt_coleta, cd_rg_doador, cd_tipo_exame, cd_funcionario, dt_exame, ic_resultado_exame)
('2016-04-15', '38.429.472-8', 1, 005, '2016-04-15', false),
('2016-04-15', '38.429.472-8', 2, 005, '2016-04-15', false),
('2016-04-15', '38.429.472-8', 3, 005, '2016-04-15', false),
('2016-04-15', '38.429.472-8', 4, 005, '2016-04-15', false),
('2016-04-15', '38.429.472-8', 5, 005, '2016-04-15', false),
('2016-04-15', '38.429.472-8', 6, 005, '2016-04-15', false),
('2015-03-25', '37.651.603-3', 1, 005, '2015-03-25', false),
('2015-03-25', '37.651.603-3', 2, 005, '2015-03-25', false),
('2015-03-25', '37.651.603-3', 3, 005, '2015-03-25', false),
('2015-03-25', '37.651.603-3', 4, 005, '2015-03-25', false),
('2015-03-25', '37.651.603-3', 5, 005, '2015-03-25', false),
('2015-03-25', '37.651.603-3', 6, 005, '2015-03-25', false),
('2016-03-27', '17.409.098-5', 1, 005, '2016-03-27', false),
('2016-03-27', '17.409.098-5', 2, 005, '2016-03-27', false),
('2016-03-27', '17.409.098-5', 3, 005, '2016-03-27', false),
('2016-03-27', '17.409.098-5', 4, 005, '2016-03-27', false),
('2016-03-27', '17.409.098-5', 5, 005, '2016-03-27', false),
('2016-03-27', '17.409.098-5', 6, 005, '2016-03-27', false),
('2016-05-12', '23.124.880-5', 1, 005, '2016-05-12', false),
('2016-05-12', '23.124.880-5', 2, 005, '2016-05-12', false),
('2016-05-12', '23.124.880-5', 3, 005, '2016-05-12', false),
('2016-05-12', '23.124.880-5', 4, 005, '2016-05-12', false),
('2016-05-12', '23.124.880-5', 5, 005, '2016-05-12', false),
('2016-05-12', '23.124.880-5', 6, 005, '2016-05-12', false);

insert into Bolsa_Fracionada
values -- (dt_coleta, cd_rg_doador, cd_tipo_fracionamento, cd_bolsa_fracionada, qt_gramas_bolsa_fracionada)
('2016-04-15', '38.429.472-8', 1, '38429472811', 100),
('2016-04-15', '38.429.472-8', 2, '38429472812', 100),
('2016-04-15', '38.429.472-8', 3, '38429472813', 100),
('2015-03-25', '37.651.603-3', 1, '37651603311', 100),
('2015-03-25', '37.651.603-3', 2, '37651603312', 100),
('2015-03-25', '37.651.603-3', 3, '37651603313', 100),
('2016-03-27', '17.409.098-5', 1, '17409098511', 100),
('2016-03-27', '17.409.098-5', 2, '17409098512', 100),
('2016-03-27', '17.409.098-5', 3, '17409098513', 100);

insert into Ocorrencia_Situacao_Bolsa
values -- (dt_ocorrencia, hr_ocorrencia, cd_situacao_bolsa, dt_coleta, cd_rg_doador, cd_tipo_fracionamento, 
	   -- cd_funcionario, ic_procedimento_realizado)
('2016-05-03', '12:35:05', 1, '2016-04-15', '38.429.472-8', 1, 9, false),
('2016-05-03', '12:35:05', 1, '2016-04-15', '38.429.472-8', 2, 9, false),
('2016-05-03', '12:35:05', 1, '2016-04-15', '38.429.472-8', 3, 9, false),
('2015-03-25', '12:35:05', 1, '2015-03-25', '37.651.603-3', 1, 9, false),
('2015-03-25', '12:35:05', 1, '2015-03-25', '37.651.603-3', 2, 9, false),
('2015-03-25', '12:35:05', 1, '2015-03-25', '37.651.603-3', 3, 9, false);
