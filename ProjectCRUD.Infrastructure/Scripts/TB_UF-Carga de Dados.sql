USE ProgramacaoWeb;

INSERT INTO TB_UF (uf_sigla, uf_nome, uf_dt_cadastro, uf_deletado)
VALUES  ('AC', 'Acre', GETDATE(), 0),
		('AL', 'Alagoas', GETDATE(), 0),
		('AP', 'Amapá', GETDATE(), 0),
		('AM', 'Amazonas', GETDATE(), 0),
		('BA', 'Bahia', GETDATE(), 0),
		('CE', 'Ceará', GETDATE(), 0),
		('DF', 'Distrito Federal', GETDATE(), 0),
		('ES', 'Espírito Santo', GETDATE(), 0),
		('GO', 'Goiânia', GETDATE(), 0),
		('MA', 'Maranhão', GETDATE(), 0),
		('MT', 'Mato Grosso', GETDATE(), 0),
		('MS', 'Mato Grosso do Sul', GETDATE(), 0),
		('MG', 'Minas Gerais', GETDATE(), 0),
		('PA', 'Pará', GETDATE(), 0),
		('PB', 'Paraíba', GETDATE(), 0),
		('PR', 'Paraná', GETDATE(), 0),
		('PE', 'Pernambuco', GETDATE(), 0),
		('PI', 'Piauí', GETDATE(), 0),
		('RJ', 'Rio de Janeiro', GETDATE(), 0),
		('RN', 'Rio Grande do Norte', GETDATE(), 0),
		('RS', 'Rio Grande do Sul', GETDATE(), 0),
		('RO', 'Rondônia', GETDATE(), 0),
		('RR', 'Roraima', GETDATE(), 0),
		('SC', 'Santa Catarina', GETDATE(), 0),
		('SP', 'São Paulo', GETDATE(), 0),
		('SE', 'Sergipe', GETDATE(), 0),
		('TO', 'Tocantins', GETDATE(), 0);

SELECT * FROM TB_UF;