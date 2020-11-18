use ProgramacaoWeb;

INSERT INTO TB_EMPRESA(emp_nm_fantasia, emp_logradouro, emp_complemento, emp_brr_codigo, emp_mnp_codigo_ibge, emp_uf_codigo, emp_cep, usr_telefone, emp_dt_cadastro, emp_dt_atualizacao, emp_deletado)
VALUES  ('Fábio e Augusto Restaurante Ltda',               'Rua Demóstenes',           591,    6,     3550308,    25,    '04614-015',    '(11) 2814-2277',    GETDATE(), GETDATE(), 0),
		('Elisa e Isadora Adega Ltda',                     'Rua Alpinópolis',          175,    7,     3518800,    25,    '07150-100',    '(11) 3702-1021',    GETDATE(), GETDATE(), 0),
		('Raimunda e Marcos Gráfica Ltda',                 'Avenida Vítor Gabriel',    367,    8,     3550308,    25,    '05788-000',    '(11) 3675-1665',    GETDATE(), GETDATE(), 0),
		('Victor e Rodrigo Lavanderia Ltda',               'Rua Armando Aguinaga',     869,    9,     3526803,    25,    '18683-590',    '(14) 3814-6132',    GETDATE(), GETDATE(), 0),
		('Bruno e Jennifer Corretores Associados ME',      'Rua Romariz',              980,    10,    3550308,    25,    '03985-110',    '(11) 2833-3019',    GETDATE(), GETDATE(), 0);

SELECT * FROM TB_EMPRESA;
