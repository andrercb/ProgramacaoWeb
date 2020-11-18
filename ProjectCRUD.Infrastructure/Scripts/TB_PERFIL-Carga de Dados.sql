use ProgramacaoWeb;

INSERT INTO TB_PERFIL (pfl_nome, pfl_descricao, pfl_dt_cadastro, pfl_dt_atualizacao, pfl_deletado)
VALUES	('Administrador', 'Administrador', GETDATE(), GETDATE(), 0),
		('Usuário',       'Usuário',       GETDATE(), GETDATE(), 0);
		

SELECT * FROM TB_PERFIL;