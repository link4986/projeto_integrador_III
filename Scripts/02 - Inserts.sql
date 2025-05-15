USE Ouvidoria

INSERT INTO  Perfil VALUES(1, 'Sindico');
INSERT INTO  Perfil VALUES(2, 'Morador');


INSERT INTO Prioridade VALUES(1, 'Alta');
INSERT INTO Prioridade VALUES(2, 'Média');
INSERT INTO Prioridade VALUES(3, 'Baixa');
INSERT INTO Prioridade VALUES(4, 'Muito Baixa');


INSERT INTO TipoReclamacao VALUES(1,'Barulho', 1,1,1)
INSERT INTO TipoReclamacao VALUES(2,'Animal solto', 1,1,1)
INSERT INTO TipoReclamacao VALUES(3,'Avaria', 1,1,1)
INSERT INTO TipoReclamacao VALUES(4,'Lixo', 1,1,1)
INSERT INTO TipoReclamacao VALUES(5,'Falta de água', 1,0,0)
INSERT INTO TipoReclamacao VALUES(6,'Falta de energia', 1,0,0)
INSERT INTO TipoReclamacao VALUES(7,'Visitante', 1,1,1)
INSERT INTO TipoReclamacao VALUES(8,'Estacionamento', 1,1,1)
INSERT INTO TipoReclamacao VALUES(9,'Outros', 1,1,1)


INSERT INTO Status VALUES(1, 'Novo');
INSERT INTO Status VALUES(2, 'Visualizado');
INSERT INTO Status VALUES(3, 'Respondido');


INSERT INTO Usuario VALUES('Síndico', 'sindico', '123456',1,1)
INSERT INTO Usuario VALUES('Morador 1', 'morador1', '123456',2,1)
INSERT INTO Usuario VALUES('Morador 2', 'morador2', '123456',2,1)
INSERT INTO Usuario VALUES('Morador 3', 'morador3', '123456',2,1)