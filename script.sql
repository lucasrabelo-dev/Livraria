-- Cria o banco de dados
CREATE DATABASE IF NOT EXISTS dblivraria;

-- Diz ao MySQL para usar esse banco
USE dblivraria;

-- Tabela dos usuários que fazem login
CREATE TABLE login (
    id INT AUTO_INCREMENT PRIMARY KEY,   -- número único, gerado sozinho
    nome VARCHAR(150) NOT NULL,          -- nome completo
    email VARCHAR(150) NOT NULL UNIQUE,  -- não pode repetir
    senha VARCHAR(100) NULL,             -- opcional (histórico)
    senhahash VARCHAR(255) NOT NULL      -- hash seguro da senha
);

-- Tabela dos livros
CREATE TABLE livro (
    id INT AUTO_INCREMENT PRIMARY KEY,
    isbn VARCHAR(20) NOT NULL UNIQUE,    -- código ISBN, não repete
    nome VARCHAR(200) NOT NULL,          -- título
    descricao TEXT,                      -- sinopse
    valor DECIMAL(10,2) NOT NULL         -- preço com 2 casas
);