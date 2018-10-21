CREATE TABLE jugador(
  jugador_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  jugador_nombre VARCHAR(50) NOT NULL,
  jugador_FechaNacimiento DATETIME NOT NULL,
  mpaa_posicion INT UNSIGNED NOT NULL,  
  jugador_pais varchar(50) NOT NULL,
  jugador_valorMercado DECIMAL(10,2) NOT NULL,
  currency VARCHAR(3) NOT NULL,
  jugador_activo BIT NOT NULL,
  club_id INT UNSIGNED NOT NULL,
  PRIMARY KEY(jugador_id),
  UNIQUE INDEX UQ_jugador_nombre_jugador_id(jugador_nombre, club_id),
  INDEX IX_jugador_club(club_id),
  CONSTRAINT FK_jugador_club_id FOREIGN KEY(club_id) REFERENCES club(club_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO jugador(jugador_nombre, jugador_FechaNacimiento, mpaa_posicion, jugador_pais, jugador_valorMercado, currency, jugador_activo, club_id) 
VALUES
('JOSE PAOLO GUERRERO GONZALES', '1984-01-01 00:00:00', 4, 'PERU', 4000000.00, 'USD', 1, 1),
('JEFFERSON AGUSTIN FARFAN GUADALUPE', '1984-10-26 00:00:00', 4, 'PERU', 2000000.00, 'USD', 1,2),
('CLAUDIO MIGUEL PIZARRO BOSIO', '1978-10-03 00:00', 4, 'PERU', 500000.00, 'USD', 1,3),
('JUAN MANUEL VARGAS RISCO', '1983-10-05 00:00', 2, 'PERU', 200000.00, 'USD', 1,4),
('ALBERTO JUNIOR RODRIGUEZ VALDELOMAR', '1984-03-31 00:00:00', 2, 'PERU', 200000.00, 'USD', 1,4);