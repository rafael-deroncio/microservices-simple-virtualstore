INSERT INTO Categories (Name, Description)
VALUES
  ('Vestuário Infantil', 'Roupas e acessórios para crianças'),
  ('Vestuário Feminino', 'Roupas e acessórios para mulheres'),
  ('Bebidas', 'Diversos tipos de bebidas'),
  ('Queijos', 'Variedades de queijos'),
  ('Eletrônicos', 'Dispositivos eletrônicos e acessórios'),
  ('Calçados', 'Sapatos, tênis e sandálias'),
  ('Perfumaria', 'Fragrâncias e produtos de beleza'),
  ('Livros', 'Livros de diferentes gêneros e temas'),
  ('Artigos Esportivos', 'Equipamentos e acessórios esportivos'),
  ('Móveis', 'Móveis para casa e escritório'),
  ('Decoração', 'Objetos decorativos para ambientes'),
  ('Brinquedos', 'Brinquedos e jogos para todas as idades'),
  ('Acessórios de Moda', 'Bolsas, cintos, óculos e mais'),
  ('Instrumentos Musicais', 'Instrumentos e acessórios musicais'),
  ('Ferramentas', 'Ferramentas para trabalhos manuais'),
  ('Alimentos Orgânicos', 'Produtos alimentícios orgânicos'),
  ('Cosméticos', 'Cosméticos e produtos de beleza'),
  ('Suplementos Alimentares', 'Suplementos e vitaminas'),
  ('Joias e Relógios', 'Joias, relógios e acessórios'),
  ('Artigos para Camping', 'Equipamentos e acessórios para camping'),
  ('Produtos para Bebês', 'Produtos para cuidados com bebês'),
  ('Artigos para Festas', 'Decoração e itens para festas'),
  ('Colecionáveis', 'Itens colecionáveis e raridades'),
  ('Suprimentos para Artesanato', 'Materiais para artesanato e DIY'),
  ('Cursos e Treinamentos', 'Cursos e treinamentos online'),
  ('Produtos para Cabelos Cacheados', 'Produtos para cabelos cacheados'),
  ('Moda Plus Size', 'Roupas e acessórios plus size'),
  ('Produtos para Barba', 'Produtos para cuidados com a barba'),
  ('Produtos para Piscina', 'Produtos para manutenção de piscinas'),
  ('Bolsas e Malas', 'Bolsas, malas e acessórios de viagem'),
  ('Acessórios para Carros', 'Acessórios e equipamentos para carros'),
  ('Produtos para Unhas', 'Produtos para cuidados com as unhas'),
  ('Moda Fitness', 'Roupas e acessórios para prática de exercícios'),
  ('Suprimentos para Pet Shop', 'Produtos e suprimentos para pet shop'),
  ('Produtos para Churrasco', 'Acessórios e utensílios para churrasco'),
  ('Produtos para Casa de Praia', 'Itens e decoração para casa de praia'),
  ('Produtos para Casa de Campo', 'Itens e decoração para casa de campo'),
  ('Produtos para Home Office', 'Acessórios e suprimentos para home office'),
  ('Produtos para Crianças Especiais', 'Produtos para crianças com necessidades especiais'),
  ('Acessórios para Celular', 'Acessórios e capas para celular'),
  ('Produtos para Confeitaria', 'Produtos e utensílios para confeitaria'),
  ('Suprimentos para Tattoo', 'Produtos e suprimentos para tatuagem'),
  ('Produtos para Pintura', 'Materiais e tintas para pintura'),
  ('Produtos para Pesca', 'Equipamentos e acessórios para pesca'),
  ('Moda Sustentável', 'Roupas e acessórios sustentáveis'),
  ('Suplementos para Animais', 'Suplementos e vitaminas para animais'),
  ('Produtos para Redes Sociais', 'Acessórios e equipamentos para redes sociais'),
  ('Produtos para Jardinagem', 'Ferramentas e acessórios para jardinagem'),
  ('Moda Vintage', 'Roupas e acessórios estilo vintage'),
  ('Produtos para Skate', 'Equipamentos e acessórios para skate'),
  ('Produtos para Yoga', 'Acessórios e equipamentos para yoga'),
  ('Produtos para Pilates', 'Acessórios e equipamentos para pilates'),
  ('Produtos para Meditação', 'Acessórios e produtos para meditação'),
  ('Produtos para Cabelos Lisos', 'Produtos para cabelos lisos'),
  ('Produtos para Cabelos Tingidos', 'Produtos para cabelos tingidos'),
  ('Produtos para Cabelos Grisalhos', 'Produtos para cabelos grisalhos'),
  ('Produtos para Cabelos Cacheados', 'Produtos para cabelos cacheados'),
  ('Moda Masculina', 'Roupas e acessórios para homens'),
  ('Produtos Naturais', 'Produtos naturais e orgânicos'),
  ('Artigos para Camping', 'Equipamentos e acessórios para camping'),
  ('Produtos para Bebês', 'Produtos para cuidados com bebês'),
  ('Suprimentos para Festas', 'Artigos e decoração para festas'),
  ('Colecionáveis', 'Itens colecionáveis e raridades'),
  ('Suprimentos para Artesanato', 'Materiais para artesanato e DIY'),
  ('Cursos e Treinamentos', 'Cursos e treinamentos online'),
  ('Produtos para Cabelos Cacheados', 'Produtos para cabelos cacheados'),
  ('Moda Plus Size', 'Roupas e acessórios plus size'); 


INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Camiseta Manga Curta', 'Camiseta de algodão com estampa divertida', 'Nike', 29.99, 50),
    ('Vestido Estampado', 'Vestido estampado com flores para meninas', 'Carters', 39.99, 30),
    ('Conjunto Moletom', 'Conjunto de moletom quentinho para crianças', 'Puma', 29.99, 20),
    ('Calça Jeans Infantil', 'Calça jeans confortável para meninos', 'Levis', 49.99, 25),
    ('Blusa de Manga Longa', 'Blusa de manga longa para crianças', 'Gap Kids', 24.99, 40),
    ('Macacão Bebê', 'Macacão confortável para bebês', 'Carters', 27.99, 25),
    ('Camiseta Manga Longa', 'Camiseta de algodão manga longa', 'H&M', 34.99, 20),
    ('Shorts Jeans', 'Shorts jeans estiloso para meninas', 'Zara Kids', 22.99, 45),
    ('Conjunto Body e Calça', 'Conjunto de body e calça para bebês', 'Ralph Lauren', 24.99, 60),
    ('Camisa Polo Infantil', 'Camisa polo elegante para crianças', 'Tommy Hilfiger', 39.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5),
    (1, 6),
    (1, 7),
    (1, 8),
    (1, 9),
    (1, 10);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vestido de Festa', 'Vestido de festa elegante para mulheres', 'Zara', 89.99, 30),
    ('Blusa de Renda', 'Blusa de renda delicada para mulheres', 'Forever 21', 29.99, 50),
    ('Calça Jeans Skinny', 'Calça jeans skinny moderna para mulheres', 'Guess', 69.99, 20),
    ('Vestido Longo Estampado', 'Vestido longo estampado para mulheres', 'H&M', 49.99, 25),
    ('Blazer Clássico', 'Blazer clássico para mulheres', 'Calvin Klein', 99.99, 20),
    ('Shorts de Linho', 'Shorts de linho confortável para mulheres', 'Mango', 39.99, 25),
    ('Saia Midi Plissada', 'Saia midi plissada elegante para mulheres', 'Topshop', 59.99, 30),
    ('Vestido Casual', 'Vestido casual versátil para mulheres', 'Zara', 44.99, 40),
    ('Camiseta Básica', 'Camiseta básica de algodão para mulheres', 'Gap', 29.99, 60),
    ('Jaqueta de Couro', 'Jaqueta de couro estilosa para mulheres', 'All Saints', 279.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (2, 11),
    (2, 12),
    (2, 13),
    (2, 14),
    (2, 15),
    (2, 16),
    (2, 17),
    (2, 18),
    (2, 19),
    (2, 20);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Cerveja Artesanal IPA', 'Cerveja artesanal Indian Pale Ale', 'Colorado', 9.99, 200),
    ('Vinho Tinto Reserva', 'Vinho tinto reserva encorpado', 'Quinta do Crasto', 29.99, 50),
    ('Whisky Single Malt', 'Whisky single malt envelhecido 12 anos', 'Glenfiddich', 59.99, 20),
    ('Rum Premium', 'Rum premium aromático e suave', 'Diplomatico', 39.99, 30),
    ('Gin Artesanal', 'Gin artesanal com infusão de ervas', 'Monkey 47', 49.99, 25),
    ('Vodka Premium', 'Vodka premium filtrada diversas vezes', 'Belvedere', 34.99, 40),
    ('Champagne Brut', 'Champagne brut de alta qualidade', 'Veuve Clicquot', 69.99, 25),
    ('Licores Variados', 'Coleção de licores diversos', 'Marie Brizard', 24.99, 60),
    ('Tequila Reposado', 'Tequila reposado envelhecida em barril de carvalho', 'Patrón', 54.99, 20),
    ('Cachaça Artesanal', 'Cachaça artesanal brasileira', 'Leblon', 29.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (3, 21),
    (3, 22),
    (3, 23),
    (3, 24),
    (3, 25),
    (3, 26),
    (3, 27),
    (3, 28),
    (3, 29),
    (3, 30);


-- Tequila Reposado
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Tequila Reposado Herradura', 'Smooth and oak-aged tequila', 'Herradura', 49.99, 20),
    ('Tequila Reposado Don Julio', 'High-quality and refined tequila', 'Don Julio', 59.99, 25),
    ('Tequila Reposado Patrón', 'Premium and handcrafted tequila', 'Patrón', 69.99, 20),
    ('Tequila Reposado Casamigos', 'Celebrities'' favorite tequila', 'Casamigos', 39.99, 25),
    ('Tequila Reposado El Tesoro', 'Artisanal and authentic tequila', 'El Tesoro', 54.99, 28),
    ('Tequila Reposado Cazadores', 'Classic and smooth tequila', 'Cazadores', 44.99, 22),
    ('Tequila Reposado Milagro', 'Distinctive and flavorful tequila', 'Milagro', 34.99, 28),
    ('Tequila Reposado Espolòn', 'Bold and traditional tequila', 'Espolòn', 29.99, 20),
    ('Tequila Reposado Avión', 'Premium tequila made from blue weber agave', 'Avión', 49.99, 25),
    ('Tequila Reposado El Jimador', 'Authentic and versatile tequila', 'El Jimador', 24.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (3, 31),
    (3, 32),
    (3, 33),
    (3, 34),
    (3, 35),
    (3, 36),
    (3, 37),
    (3, 38),
    (3, 39),
    (3, 40);

-- Queijo Gouda
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Gouda Boar''s Head', 'Rich and creamy Dutch cheese', 'Boar''s Head', 9.99, 30),
    ('Queijo Gouda Beemster', 'Aged and flavorful Gouda cheese', 'Beemster', 22.99, 25),
    ('Queijo Gouda Vermeer', 'Smooth and nutty Gouda cheese', 'Vermeer', 21.99, 20),
    ('Queijo Gouda Reypenaer', 'Award-winning Gouda cheese', 'Reypenaer', 24.99, 28),
    ('Queijo Gouda Leyden', 'Spiced and aromatic Gouda cheese', 'Leyden', 20.99, 22),
    ('Queijo Gouda Henri Willig', 'Handcrafted Gouda cheese', 'Henri Willig', 23.99, 20),
    ('Queijo Gouda Beemster Vlaskaas', 'Flaxseed-coated Gouda cheese', 'Beemster', 25.99, 25),
    ('Queijo Gouda Old Amsterdam', 'Intensely flavored and mature Gouda cheese', 'Old Amsterdam', 26.99, 22),
    ('Queijo Gouda Marieke', 'Artisanal Gouda cheese from Wisconsin', 'Marieke', 27.99, 20),
    ('Queijo Gouda Azeitão', 'Portuguese-style Gouda cheese', 'Azeitão', 9.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 31),
    (4, 32),
    (4, 33),
    (4, 34),
    (4, 35),
    (4, 36),
    (4, 37),
    (4, 38),
    (4, 39),
    (4, 40);

-- Queijo Brie
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Brie President', 'Creamy and mild French cheese', 'President', 7.99, 30),
    ('Queijo Brie Le Chatelain', 'Rich and buttery Brie cheese', 'Le Chatelain', 9.99, 25),
    ('Queijo Brie Rouzaire', 'Soft and velvety Brie cheese', 'Rouzaire', 8.99, 20),
    ('Queijo Brie Delin', 'Traditional French Brie cheese', 'Delin', 21.99, 28),
    ('Queijo Brie Ile de France', 'Classic and indulgent Brie cheese', 'Ile de France', 20.99, 22),
    ('Queijo Brie La Bonne Vie', 'Artisanal Brie cheese from Vermont', 'La Bonne Vie', 23.99, 20),
    ('Queijo Brie Marin French Cheese', 'Organic Brie cheese made in California', 'Marin French Cheese', 25.99, 25),
    ('Queijo Brie Rouzaire Truffé', 'Truffle-infused Brie cheese', 'Rouzaire', 26.99, 22),
    ('Queijo Brie Le Chatelain Figue', 'Brie cheese with figs', 'Le Chatelain', 27.99, 20),
    ('Queijo Brie Triple Crème', 'Luxurious and triple-creme Brie cheese', 'Triple Crème', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 41),
    (4, 42),
    (4, 43),
    (4, 44),
    (4, 45),
    (4, 46),
    (4, 47),
    (4, 48),
    (4, 49),
    (4, 50);

-- Queijo Cheddar
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Cheddar Cabot', 'Sharp and creamy Vermont cheddar cheese', 'Cabot', 8.99, 30),
    ('Queijo Cheddar Tillamook', 'Award-winning cheddar cheese from Oregon', 'Tillamook', 20.99, 25),
    ('Queijo Cheddar Kerrygold', 'Rich and flavorful Irish cheddar cheese', 'Kerrygold', 9.99, 20),
    ('Queijo Cheddar Cathedral City', 'Smooth and traditional British cheddar cheese', 'Cathedral City', 21.99, 28),
    ('Queijo Cheddar Wyke Farms', 'Farmhouse-style cheddar cheese', 'Wyke Farms', 20.99, 22),
    ('Queijo Cheddar Black Diamond', 'Classic Canadian cheddar cheese', 'Black Diamond', 23.99, 20),
    ('Queijo Cheddar Barber''s', 'Authentic West Country cheddar cheese', 'Barber''s', 25.99, 25),
    ('Queijo Cheddar Red Leicester', 'Colorful and nutty cheddar cheese', 'Red Leicester', 26.99, 22),
    ('Queijo Cheddar Applewood', 'Smoked cheddar cheese with a hint of applewood', 'Applewood', 27.99, 20),
    ('Queijo Cheddar Collier''s', 'Full-bodied and mature Welsh cheddar cheese', 'Collier''s', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 51),
    (4, 52),
    (4, 53),
    (4, 54),
    (4, 55),
    (4, 56),
    (4, 57),
    (4, 58),
    (4, 59),
    (4, 60);

-- Queijo Roquefort
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Roquefort Société', 'Intense and crumbly blue cheese', 'Société', 21.99, 30),
    ('Queijo Roquefort Papillon', 'Classic and artisanal Roquefort cheese', 'Papillon', 23.99, 25),
    ('Queijo Roquefort Carles', 'Traditional and creamy Roquefort cheese', 'Carles', 22.99, 20),
    ('Queijo Roquefort Gabriel Coulet', 'Rich and tangy Roquefort cheese', 'Gabriel Coulet', 25.99, 28),
    ('Queijo Roquefort Vernières', 'Distinctive and aged Roquefort cheese', 'Vernières', 24.99, 22),
    ('Queijo Roquefort Le Vieux Berger', 'Sheep milk Roquefort cheese', 'Le Vieux Berger', 27.99, 20),
    ('Queijo Roquefort La Pastourelle', 'Artisanal and handcrafted Roquefort cheese', 'La Pastourelle', 29.99, 25),
    ('Queijo Roquefort Rouges', 'Semi-soft and creamy Roquefort cheese', 'Rouges', 20.99, 22),
    ('Queijo Roquefort Agour', 'Complex and velvety Roquefort cheese', 'Agour', 21.99, 20),
    ('Queijo Roquefort Aveyron', 'Traditional blue cheese from Aveyron', 'Aveyron', 26.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 61),
    (4, 62),
    (4, 63),
    (4, 64),
    (4, 65),
    (4, 66),
    (4, 67),
    (4, 68),
    (4, 69),
    (4, 70);

-- Queijo Cheddar
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Cheddar Cabot', 'Sharp and creamy Vermont cheddar cheese', 'Cabot', 8.99, 30),
    ('Queijo Cheddar Tillamook', 'Award-winning cheddar cheese from Oregon', 'Tillamook', 20.99, 25),
    ('Queijo Cheddar Kerrygold', 'Rich and flavorful Irish cheddar cheese', 'Kerrygold', 9.99, 20),
    ('Queijo Cheddar Cathedral City', 'Smooth and traditional British cheddar cheese', 'Cathedral City', 21.99, 28),
    ('Queijo Cheddar Wyke Farms', 'Farmhouse-style cheddar cheese', 'Wyke Farms', 20.99, 22),
    ('Queijo Cheddar Black Diamond', 'Classic Canadian cheddar cheese', 'Black Diamond', 23.99, 20),
    ('Queijo Cheddar Barber''s', 'Authentic West Country cheddar cheese', 'Barber''s', 25.99, 25),
    ('Queijo Cheddar Red Leicester', 'Colorful and nutty cheddar cheese', 'Red Leicester', 26.99, 22),
    ('Queijo Cheddar Applewood', 'Smoked cheddar cheese with a hint of applewood', 'Applewood', 27.99, 20),
    ('Queijo Cheddar Collier''s', 'Full-bodied and mature Welsh cheddar cheese', 'Collier''s', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 71),
    (4, 72),
    (4, 73),
    (4, 74),
    (4, 75),
    (4, 76),
    (4, 77),
    (4, 78),
    (4, 79),
    (4, 80);

-- Queijo Parmesão
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Parmesão Reggiano', 'Traditional Italian Parmesan cheese', 'Reggiano', 20.99, 30),
    ('Queijo Parmesão Grana Padano', 'Hard and grainy Italian cheese', 'Grana Padano', 21.99, 25),
    ('Queijo Parmesão Pecorino Romano', 'Salty and sharp Italian cheese', 'Pecorino Romano', 22.99, 20),
    ('Queijo Parmesão BelGioioso', 'Creamy and aged Parmesan cheese', 'BelGioioso', 23.99, 28),
    ('Queijo Parmesão Sartori', 'Handcrafted Parmesan cheese from Wisconsin', 'Sartori', 24.99, 22),
    ('Queijo Parmesão Cello', 'Buttery and nutty Parmesan cheese', 'Cello', 25.99, 20),
    ('Queijo Parmesão Auricchio', 'Versatile and flavorful Parmesan cheese', 'Auricchio', 26.99, 25),
    ('Queijo Parmesão Vella', 'Aged and tangy Parmesan cheese', 'Vella', 27.99, 22),
    ('Queijo Parmesão Di Bruno Bros', 'Gourmet Parmesan cheese from Di Bruno Bros', 'Di Bruno Bros', 28.99, 20),
    ('Queijo Parmesão Murray''s', 'Artisanal Parmesan cheese from Murray''s', 'Murray''s', 29.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 91),
    (4, 92),
    (4, 93),
    (4, 94),
    (4, 95),
    (4, 96),
    (4, 97),
    (4, 98),
    (4, 99),
    (4, 100);

-- Queijo Gorgonzola
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Gorgonzola Dolce', 'Creamy and mild Italian blue cheese', 'Dolce', 9.99, 30),
    ('Queijo Gorgonzola Piccante', 'Sharp and pungent Italian blue cheese', 'Piccante', 21.99, 25),
    ('Queijo Gorgonzola Igor', 'Traditional and crumbly Gorgonzola cheese', 'Igor', 20.99, 20),
    ('Queijo Gorgonzola Arrigoni', 'Complex and tangy Gorgonzola cheese', 'Arrigoni', 23.99, 28),
    ('Queijo Gorgonzola Galbani', 'Creamy and rich Gorgonzola cheese', 'Galbani', 22.99, 22),
    ('Queijo Gorgonzola Gran Lombardo', 'Intense and robust Gorgonzola cheese', 'Gran Lombardo', 25.99, 20),
    ('Queijo Gorgonzola Mauri', 'Traditional blue cheese from Mauri', 'Mauri', 24.99, 25),
    ('Queijo Gorgonzola Luigi Guffanti', 'Artisanal Gorgonzola cheese from Luigi Guffanti', 'Luigi Guffanti', 27.99, 22),
    ('Queijo Gorgonzola Veroni', 'Smooth and creamy Gorgonzola cheese', 'Veroni', 26.99, 20),
    ('Queijo Gorgonzola Colombo', 'Creamy and full-flavored Gorgonzola cheese', 'Colombo', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 101),
    (4, 102),
    (4, 103),
    (4, 104),
    (4, 105),
    (4, 106),
    (4, 107),
    (4, 108),
    (4, 109),
    (4, 110);

-- Queijo Cottage
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Cottage Minerva', 'Smooth and creamy cottage cheese', 'Minerva', 6.99, 30),
    ('Queijo Cottage Batavo', 'Light and fresh cottage cheese', 'Batavo', 7.99, 25),
    ('Queijo Cottage Verde Campo', 'Organic and natural cottage cheese', 'Verde Campo', 8.99, 20),
    ('Queijo Cottage Tirolez', 'Creamy and low-fat cottage cheese', 'Tirolez', 9.99, 28),
    ('Queijo Cottage Laticínios Scala', 'Traditional cottage cheese from Laticínios Scala', 'Laticínios Scala', 8.99, 22),
    ('Queijo Cottage Nutri', 'Protein-rich cottage cheese', 'Nutri', 20.99, 20),
    ('Queijo Cottage Paulista', 'Classic cottage cheese from Paulista', 'Paulista', 21.99, 25),
    ('Queijo Cottage Tirol', 'Fresh and creamy cottage cheese', 'Tirol', 22.99, 22),
    ('Queijo Cottage Lac Lélo', 'Soft and mild cottage cheese', 'Lac Lélo', 23.99, 20),
    ('Queijo Cottage Arosa', 'Light and creamy cottage cheese', 'Arosa', 9.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 111),
    (4, 112),
    (4, 113),
    (4, 114),
    (4, 115),
    (4, 116),
    (4, 117),
    (4, 118),
    (4, 119),
    (4, 120);
    
-- Queijo Camembert
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Camembert President', 'Creamy and bloomy-rind Camembert cheese', 'President', 7.99, 30),
    ('Queijo Camembert Isigny Ste Mère', 'Artisanal Camembert cheese from Isigny Ste Mère', 'Isigny Ste Mère', 8.99, 25),
    ('Queijo Camembert Rouzaire', 'Buttery and soft Camembert cheese', 'Rouzaire', 9.99, 20),
    ('Queijo Camembert Le Chatelain', 'Traditional Camembert cheese from Le Chatelain', 'Le Chatelain', 20.99, 28),
    ('Queijo Camembert Gillot', 'Rich and aromatic Camembert cheese', 'Gillot', 9.99, 22),
    ('Queijo Camembert Lincet', 'Delicate and creamy Camembert cheese', 'Lincet', 22.99, 20),
    ('Queijo Camembert Fauquet', 'Traditional Normandy Camembert cheese', 'Fauquet', 21.99, 25),
    ('Queijo Camembert Le Rustique', 'Full-flavored and authentic Camembert cheese', 'Le Rustique', 23.99, 22),
    ('Queijo Camembert Coeur de Lion', 'Smooth and creamy Camembert cheese', 'Coeur de Lion', 24.99, 20),
    ('Queijo Camembert Lanquetot', 'Mellow and velvety Camembert cheese', 'Lanquetot', 20.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 121),
    (4, 122),
    (4, 123),
    (4, 124),
    (4, 125),
    (4, 126),
    (4, 127),
    (4, 128),
    (4, 129),
    (4, 130);
    
-- Queijo Provolone
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Provolone Auricchio', 'Sharp and smoky Italian Provolone cheese', 'Auricchio', 8.99, 30),
    ('Queijo Provolone Mandi', 'Creamy and mild Provolone cheese', 'Mandi', 9.99, 25),
    ('Queijo Provolone Boar''s Head', 'Savory and authentic Provolone cheese', 'Boar''s Head', 20.99, 20),
    ('Queijo Provolone Belgioioso', 'Full-bodied and tangy Provolone cheese', 'Belgioioso', 21.99, 28),
    ('Queijo Provolone Paganini', 'Smooth and buttery Provolone cheese', 'Paganini', 20.99, 22),
    ('Queijo Provolone Giorgio''s', 'Handcrafted Provolone cheese from Giorgio''s', 'Giorgio''s', 23.99, 20),
    ('Queijo Provolone Locatelli', 'Sharp and robust Provolone cheese', 'Locatelli', 22.99, 25),
    ('Queijo Provolone La Bottega', 'Semi-soft and smoky Provolone cheese', 'La Bottega', 24.99, 22),
    ('Queijo Provolone Crotonese', 'Aged and flavorful Provolone cheese', 'Crotonese', 25.99, 20),
    ('Queijo Provolone Vantia', 'Creamy and tangy Provolone cheese', 'Vantia', 21.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 131),
    (4, 132),
    (4, 133),
    (4, 134),
    (4, 135),
    (4, 136),
    (4, 137),
    (4, 138),
    (4, 139),
    (4, 140);
    
-- Queijo Gruyère
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Queijo Gruyère Le Cret', 'Smooth and nutty Swiss Gruyère cheese', 'Le Cret', 9.99, 30),
    ('Queijo Gruyère Emmi', 'Classic Swiss Gruyère cheese', 'Emmi', 20.99, 25),
    ('Queijo Gruyère L''Etivaz', 'Artisanal Gruyère cheese from L''Etivaz', 'L''Etivaz', 21.99, 20),
    ('Queijo Gruyère Le Gruyérien', 'Aged and flavorful Gruyère cheese', 'Le Gruyérien', 22.99, 28),
    ('Queijo Gruyère Cave Aged', 'Rich and complex Gruyère cheese', 'Cave Aged', 21.99, 22),
    ('Queijo Gruyère Le Châtelard', 'Handcrafted Gruyère cheese from Le Châtelard', 'Le Châtelard', 24.99, 20),
    ('Queijo Gruyère Bergmännli', 'Full-flavored and aromatic Gruyère cheese', 'Bergmännli', 23.99, 25),
    ('Queijo Gruyère Préféré', 'Smooth and creamy Gruyère cheese', 'Préféré', 25.99, 22),
    ('Queijo Gruyère Schmid', 'Mild and balanced Gruyère cheese', 'Schmid', 26.99, 20),
    ('Queijo Gruyère Urchig', 'Robust and aged Gruyère cheese', 'Urchig', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (4, 141),
    (4, 142),
    (4, 143),
    (4, 144),
    (4, 145),
    (4, 146),
    (4, 147),
    (4, 148),
    (4, 149),
    (4, 150);
    
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Smartphone', 'Smartphone avançado com câmera de alta resolução', 'Samsung', 799.99, 50),
    ('Notebook', 'Notebook leve e potente para uso profissional', 'Dell', 2299.99, 30),
    ('Smart TV', 'Smart TV com tela de alta definição', 'LG', 899.99, 20),
    ('Fones de Ouvido Bluetooth', 'Fones de ouvido sem fio com cancelamento de ruído', 'Sony', 299.99, 40),
    ('Console de Videogame', 'Console de videogame com gráficos de última geração', 'Microsoft', 499.99, 25),
    ('Câmera Digital', 'Câmera digital de alta resolução para fotografia profissional', 'Canon', 699.99, 20),
    ('Tablet', 'Tablet com tela sensível ao toque e alto desempenho', 'Apple', 399.99, 25),
    ('Impressora Multifuncional', 'Impressora que também funciona como scanner e copiadora', 'Epson', 249.99, 30),
    ('Roteador Wi-Fi', 'Roteador sem fio para conexão de internet estável', 'TP-Link', 59.99, 60),
    ('Caixa de Som Bluetooth', 'Caixa de som portátil com conectividade Bluetooth', 'JBL', 79.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (5, 151),
    (5, 152),
    (5, 153),
    (5, 154),
    (5, 155),
    (5, 156),
    (5, 157),
    (5, 158),
    (5, 159),
    (5, 160);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Tênis Esportivo', 'Tênis esportivo confortável para práticas esportivas', 'Nike', 99.99, 100),
    ('Sapato Social Masculino', 'Sapato social elegante para homens', 'Calvin Klein', 129.99, 50),
    ('Sandália de Salto Alto', 'Sandália de salto alto feminina', 'Schutz', 79.99, 20),
    ('Bota de Couro', 'Bota de couro resistente para uso casual', 'Timberland', 149.99, 30),
    ('Sapatilha Feminina', 'Sapatilha feminina confortável para uso diário', 'Arezzo', 59.99, 25),
    ('Chinelo Slide', 'Chinelo slide unissex estiloso', 'Adidas', 29.99, 40),
    ('Bota de Neve', 'Bota de neve impermeável para atividades de inverno', 'Columbia', 129.99, 15),
    ('Tênis Casual', 'Tênis casual versátil para uso cotidiano', 'Vans', 69.99, 60),
    ('Sandália Rasteira', 'Sandália rasteira confortável para o verão', 'Ipanema', 39.99, 20),
    ('Sapato Oxford', 'Sapato oxford clássico e elegante', 'Dr. Martens', 119.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (6, 161),
    (6, 162),
    (6, 163),
    (6, 164),
    (6, 165),
    (6, 166),
    (6, 167),
    (6, 168),
    (6, 169),
    (6, 170);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Perfume Masculino', 'Perfume masculino marcante e sofisticado', 'Dior', 89.99, 100),
    ('Perfume Feminino', 'Perfume feminino delicado e envolvente', 'Chanel', 99.99, 50),
    ('Perfume Unissex', 'Perfume unissex versátil e elegante', 'Tom Ford', 119.99, 20),
    ('Colônia Infantil', 'Colônia infantil suave e refrescante', 'Johnson & Johnson', 29.99, 30),
    ('Perfume Esportivo', 'Perfume esportivo revigorante', 'Paco Rabanne', 79.99, 25),
    ('Perfume Oriental', 'Perfume oriental com notas exóticas', 'Yves Saint Laurent', 109.99, 40),
    ('Água de Colônia', 'Água de colônia refrescante para uso diário', 'Natura', 39.99, 15),
    ('Perfume Cítrico', 'Perfume cítrico energizante', 'Acqua di Parma', 69.99, 60),
    ('Perfume Floral', 'Perfume floral romântico', 'Guerlain', 89.99, 20),
    ('Perfume Amadeirado', 'Perfume amadeirado sofisticado', 'Hermès', 99.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (7, 171),
    (7, 172),
    (7, 173),
    (7, 174),
    (7, 175),
    (7, 176),
    (7, 177),
    (7, 178),
    (7, 179),
    (7, 170);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Romance Bestseller', 'Romance bestseller do New York Times', 'Autor A', 29.99, 200),
    ('Livro de Ficção Científica', 'Livro de ficção científica premiado', 'Autor B', 24.99, 50),
    ('Livro de Autoajuda', 'Livro de autoajuda para o crescimento pessoal', 'Autor C', 24.99, 20),
    ('Livro de Mistério e Suspense', 'Livro de mistério e suspense eletrizante', 'Autor D', 26.99, 30),
    ('Livro de Biografia', 'Livro de biografia de uma figura histórica', 'Autor E', 21.99, 25),
    ('Livro de Poesia', 'Livro de poesia contemporânea', 'Autor F', 22.99, 40),
    ('Livro de História', 'Livro de história mundial', 'Autor G', 27.99, 25),
    ('Livro de Negócios', 'Livro de negócios e empreendedorismo', 'Autor H', 29.99, 60),
    ('Livro de Arte', 'Livro de arte com belas ilustrações', 'Autor I', 29.99, 20),
    ('Livro de Fantasia', 'Livro de fantasia épica', 'Autor J', 26.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (8, 171),
    (8, 172),
    (8, 173),
    (8, 174),
    (8, 175),
    (8, 176),
    (8, 177),
    (8, 178),
    (8, 179),
    (8, 180);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Bola de Futebol', 'Bola de futebol oficial para partidas', 'Nike', 29.99, 200),
    ('Raquete de Tênis', 'Raquete de tênis profissional', 'Wilson', 99.99, 50),
    ('Luvas de Boxe', 'Luvas de boxe profissionais', 'Everlast', 59.99, 20),
    ('Bicicleta Mountain Bike', 'Bicicleta mountain bike para trilhas', 'Scott', 499.99, 30),
    ('Skate', 'Skate completo para manobras radicais', 'Element', 89.99, 25),
    ('Bola de Basquete', 'Bola de basquete oficial para jogos', 'Spalding', 29.99, 40),
    ('Taco de Baseball', 'Taco de baseball profissional', 'Louisville Slugger', 49.99, 25),
    ('Rede de Vôlei', 'Rede de vôlei oficial para competições', 'Mikasa', 39.99, 60),
    ('Prancha de Surf', 'Prancha de surf para ondas grandes', 'Channel Islands', 299.99, 20),
    ('Bola de Golfe', 'Bola de golfe profissional', 'Titleist', 9.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (9, 181),
    (9, 182),
    (9, 183),
    (9, 184),
    (9, 185),
    (9, 186),
    (9, 187),
    (9, 188),
    (9, 189),
    (9, 190);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Sofá de Couro', 'Sofá de couro elegante e confortável', 'Vitaly', 999.99, 20),
    ('Mesa de Jantar', 'Mesa de jantar de madeira maciça', 'Etna', 499.99, 25),
    ('Cama de Casal', 'Cama de casal com estrutura resistente', 'Tok&Stok', 899.99, 20),
    ('Estante Modular', 'Estante modular com design moderno', 'Meu Móvel de Madeira', 349.99, 25),
    ('Cadeira de Escritório', 'Cadeira de escritório ergonômica', 'Flexform', 299.99, 30),
    ('Armário Multiuso', 'Armário multiuso com prateleiras ajustáveis', 'Henn', 279.99, 22),
    ('Rack para TV', 'Rack para TV com compartimentos espaçosos', 'Madesa', 299.99, 28),
    ('Mesa de Centro', 'Mesa de centro com tampo de vidro', 'Oppa', 249.99, 20),
    ('Guarda-Roupa Casal', 'Guarda-roupa casal com espelho e gavetas', 'Rufato', 799.99, 8),
    ('Cômoda Infantil', 'Cômoda infantil com design divertido', 'Casatema', 249.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (10, 191),
    (10, 192),
    (10, 193),
    (10, 194),
    (10, 195),
    (10, 196),
    (10, 197),
    (10, 198),
    (10, 199),
    (10, 200);


INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vaso Decorativo', 'Vaso de cerâmica com detalhes pintados à mão', 'Casa das Porcelanas', 49.99, 30),
    ('Quadro Abstrato', 'Quadro abstrato em tela com moldura elegante', 'Arte em Tela', 99.99, 20),
    ('Cortina Estampada', 'Cortina estampada para sala ou quarto', 'Cortinaria', 79.99, 25),
    ('Tapete Felpudo', 'Tapete felpudo de alta qualidade', 'Tapetes São Carlos', 249.99, 20),
    ('Candelabro de Cristal', 'Candelabro de cristal com design clássico', 'Maria Pia Casa', 299.99, 8),
    ('Espelho Decorativo', 'Espelho decorativo com moldura rústica', 'Madeira e Arte', 79.99, 22),
    ('Pufe Retangular', 'Pufe retangular com estampa geométrica', 'Lar Decorações', 69.99, 28),
    ('Porta-Retrato', 'Porta-retrato de metal com acabamento em prata', 'Arte & Moldura', 29.99, 25),
    ('Luminária de Mesa', 'Luminária de mesa com base de madeira', 'Iluminar', 59.99, 20),
    ('Enfeite Decorativo', 'Enfeite decorativo em formato de pássaro', 'Decore & Encante', 29.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (11, 201),
    (11, 202),
    (11, 203),
    (11, 204),
    (11, 205),
    (11, 206),
    (11, 207),
    (11, 208),
    (11, 209),
    (11, 210);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Boneca de Pelúcia', 'Boneca de pelúcia macia e antialérgica', 'Buba', 39.99, 50),
    ('Carrinho de Controle Remoto', 'Carrinho de controle remoto com alta velocidade', 'Candide', 89.99, 30),
    ('Quebra-Cabeça Infantil', 'Quebra-cabeça com ilustrações coloridas', 'Toyster', 29.99, 200),
    ('Jogo de Tabuleiro', 'Jogo de tabuleiro estratégico para toda a família', 'Grow', 49.99, 40),
    ('Bicicleta Infantil', 'Bicicleta infantil com rodinhas laterais', 'Caloi', 299.99, 20),
    ('Pelúcia Interativa', 'Pelúcia interativa que fala e canta', 'Multikids', 79.99, 25),
    ('Kit de Ferramentas', 'Kit de ferramentas infantil com peças coloridas', 'Xalingo', 29.99, 60),
    ('Pista de Corrida', 'Pista de corrida com loops e curvas emocionantes', 'Braskit', 69.99, 35),
    ('Boneco Articulado', 'Boneco articulado com movimentos realistas', 'Hasbro', 49.99, 30),
    ('Patins Infantis', 'Patins ajustáveis para crianças', 'Traxart', 89.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (12, 211),
    (12, 212),
    (12, 213),
    (12, 214),
    (12, 215),
    (12, 216),
    (12, 217),
    (12, 218),
    (12, 219),
    (12, 220);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Bolsa de Couro', 'Bolsa de couro legítimo', 'Louis Vuitton', 299.99, 50),
    ('Óculos de Sol', 'Óculos de sol estilo aviador', 'Ray-Ban', 249.99, 30),
    ('Colar de Prata', 'Colar feminino em prata 925', 'Pandora', 89.99, 20),
    ('Cinto de Couro', 'Cinto de couro com fivela dourada', 'Hermès', 79.99, 40),
    ('Chapéu Fedora', 'Chapéu fedora em lã', 'Goorin Bros', 49.99, 25),
    ('Lenço de Seda', 'Lenço de seda estampado', 'Versace', 69.99, 25),
    ('Brinco de Pérola', 'Brinco de pérola natural', 'Tiffany & Co.', 229.99, 20),
    ('Carteira de Couro', 'Carteira de couro com compartimentos', 'Gucci', 99.99, 30),
    ('Relógio de Pulso', 'Relógio de pulso analógico', 'Fossil', 299.99, 20),
    ('Lenços de Cabelo', 'Conjunto de lenços de cabelo', 'Hermès', 59.99, 35);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (13, 221),
    (13, 222),
    (13, 223),
    (13, 224),
    (13, 225),
    (13, 226),
    (13, 227),
    (13, 228),
    (13, 229),
    (13, 230);

	
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Guitarra Elétrica', 'Guitarra elétrica de seis cordas', 'Fender', 999.99, 20),
    ('Bateria Acústica', 'Bateria acústica de 5 peças', 'Pearl', 2499.99, 5),
    ('Teclado Digital', 'Teclado digital de 88 teclas', 'Yamaha', 699.99, 25),
    ('Violão Clássico', 'Violão clássico de nylon', 'Cordoba', 399.99, 20),
    ('Baixo Elétrico', 'Baixo elétrico de 4 cordas', 'Ibanez', 799.99, 8),
    ('Saxofone Tenor', 'Saxofone tenor profissional', 'Yanagisawa', 2999.99, 3),
    ('Piano de Cauda', 'Piano de cauda de concerto', 'Steinway & Sons', 9999.99, 2),
    ('Flauta Transversal', 'Flauta transversal de prata', 'Miyazawa', 2499.99, 5),
    ('Trompete', 'Trompete profissional em si bemol', 'Bach', 799.99, 20),
    ('Acordeão', 'Acordeão de piano de 120 baixos', 'Hohner', 2499.99, 4);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (14, 231),
    (14, 232),
    (14, 233),
    (14, 234),
    (14, 235),
    (14, 236),
    (14, 237),
    (14, 238),
    (14, 239),
    (14, 240);
	
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Furadeira Sem Fio', 'Furadeira sem fio com bateria de lítio', 'DeWalt', 299.99, 20),
    ('Parafusadeira Elétrica', 'Parafusadeira elétrica com torque ajustável', 'Bosch', 249.99, 25),
    ('Chave de Fenda Conjunto', 'Conjunto de chaves de fenda com diferentes tamanhos', 'Stanley', 39.99, 30),
    ('Serra Circular', 'Serra circular com lâmina de 7-1/4 polegadas', 'Makita', 229.99, 25),
    ('Martelo de Garra', 'Martelo de garra com cabo de fibra de vidro', 'Estwing', 49.99, 20),
    ('Alicate Universal', 'Alicate universal com cabo emborrachado', 'Irwin', 29.99, 40),
    ('Trena de Medição', 'Trena de medição com fita de 5 metros', 'Komelon', 24.99, 50),
    ('Nível a Laser', 'Nível a laser com feixe verde', 'Bosch', 249.99, 8),
    ('Escova de Pintura', 'Escova de pintura de cerdas sintéticas', 'Purdy', 9.99, 60),
    ('Brocas para Metal', 'Conjunto de brocas para metal de alta velocidade', 'Dormer', 24.99, 35);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (15, 241),
    (15, 242),
    (15, 243),
    (15, 244),
    (15, 245),
    (15, 246),
    (15, 247),
    (15, 248),
    (15, 249),
    (15, 250);
	
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Azeite de Oliva Extra Virgem', 'Azeite de oliva extra virgem de primeira prensagem', 'Saboroso', 29.99, 50),
    ('Mel Puro', 'Mel puro e natural', 'Apiário Flor da Serra', 22.99, 40),
    ('Chocolate Amargo', 'Tablete de chocolate amargo 70% cacau', 'Cacau Brasil', 7.99, 30),
    ('Café Orgânico', 'Café orgânico em grãos', 'Sítio São Pedro', 9.99, 60),
    ('Arroz Integral', 'Arroz integral 100% orgânico', 'Fazenda Feliz', 4.99, 80),
    ('Feijão Preto', 'Feijão preto orgânico', 'Sítio das Palmeiras', 3.99, 70),
    ('Tomate Orgânico', 'Tomate orgânico fresco', 'Horta do Sítio', 2.99, 90),
    ('Maçãs Orgânicas', 'Maçãs orgânicas frescas', 'Pomar da Serra', 2.99, 200),
    ('Abacate Orgânico', 'Abacate orgânico maduro', 'Fazenda São José', 3.49, 60),
    ('Melancia Orgânica', 'Melancia orgânica doce e suculenta', 'Sítio do Sol', 6.99, 40);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (16, 251),
    (16, 252),
    (16, 253),
    (16, 254),
    (16, 255),
    (16, 256),
    (16, 257),
    (16, 258),
    (16, 259),
    (16, 260);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Creme Facial Hidratante', 'Creme facial hidratante para pele seca', 'Nivea', 29.99, 30),
    ('Shampoo Anticaspa', 'Shampoo anticaspa para couro cabeludo sensível', 'Head & Shoulders', 9.99, 50),
    ('Batom Matte', 'Batom matte de longa duração', 'MAC', 24.99, 20),
    ('Perfume Feminino', 'Perfume feminino floral e sedutor', 'Chanel', 99.99, 25),
    ('Máscara Capilar', 'Máscara capilar reparadora de danos', 'Pantene', 22.99, 25),
    ('Loção Corporal Hidratante', 'Loção corporal hidratante de rápida absorção', 'Nivea', 21.99, 35),
    ('Delineador Líquido', 'Delineador líquido de longa duração', 'Maybelline', 7.99, 40),
    ('Desodorante Roll-On', 'Desodorante roll-on com proteção de 48 horas', 'Rexona', 4.99, 60),
    ('Pó Compacto', 'Pó compacto com acabamento natural', 'Vult', 9.99, 30),
    ('Removedor de Maquiagem', 'Removedor de maquiagem bifásico', 'Neutrogena', 8.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (17, 261),
    (17, 262),
    (17, 263),
    (17, 264),
    (17, 265),
    (17, 266),
    (17, 267),
    (17, 268),
    (17, 269),
    (17, 270);
	
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Whey Protein', 'Suplemento proteico para ganho de massa muscular', 'Optimum Nutrition', 49.99, 30),
    ('BCAA', 'Suplemento de aminoácidos de cadeia ramificada', 'MuscleTech', 29.99, 40),
    ('Creatina', 'Suplemento para aumento de força e energia', 'Dymatize', 29.99, 50),
    ('Glutamina', 'Suplemento para recuperação muscular', 'Universal Nutrition', 24.99, 35),
    ('Multivitamínico', 'Suplemento multivitamínico para saúde geral', 'Nature Made', 24.99, 45),
    ('Ômega-3', 'Suplemento de ácidos graxos ômega-3', 'Now Foods', 9.99, 60),
    ('Pré-Treino', 'Suplemento pré-treino para aumento de energia', 'Cellucor', 39.99, 25),
    ('Colágeno', 'Suplemento de colágeno para pele e articulações', 'NeoCell', 29.99, 30),
    ('Vitamina D', 'Suplemento de vitamina D para saúde óssea', 'Nature s Bounty', 22.99, 50),
    ('ZMA', 'Suplemento de zinco, magnésio e vitamina B6', 'Optimum Nutrition', 29.99, 40);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (18, 271),
    (18, 272),
    (18, 273),
    (18, 274),
    (18, 275),
    (18, 276),
    (18, 277),
    (18, 278),
    (18, 279),
    (18, 280);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Anel de Diamante', 'Anel de ouro branco com diamante', 'Tiffany & Co.', 2999.99, 20),
    ('Relógio de Pulso Feminino', 'Relógio de pulso feminino com pulseira de couro', 'Michael Kors', 299.99, 8),
    ('Pulseira de Prata', 'Pulseira de prata esterlina com pingentes', 'Pandora', 249.99, 25),
    ('Colar de Pérolas', 'Colar de pérolas naturais com fecho de ouro', 'Mikimoto', 799.99, 5),
    ('Relógio de Pulso Masculino', 'Relógio de pulso masculino com pulseira de aço inoxidável', 'Tag Heuer', 999.99, 3),
    ('Brinco de Ouro', 'Brinco de ouro amarelo com pedra de zircônia', 'Vivara', 249.99, 22),
    ('Anel de Prata', 'Anel de prata esterlina com detalhes em relevo', 'Tous', 79.99, 20),
    ('Relógio de Bolso', 'Relógio de bolso vintage com corrente', 'Casio', 299.99, 6),
    ('Pingente de Diamante', 'Pingente de ouro branco com diamante', 'Cartier', 599.99, 4),
    ('Pulseira de Ouro', 'Pulseira de ouro amarelo 18k', 'H.Stern', 2499.99, 3);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (19, 281),
    (19, 282),
    (19, 283),
    (19, 284),
    (19, 285),
    (19, 286),
    (19, 287),
    (19, 288),
    (19, 289),
    (19, 290);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Barraca para Camping 4 Pessoas', 'Barraca resistente para camping com capacidade para 4 pessoas', 'CampingLife', 249.99, 30),
    ('Saco de Dormir', 'Saco de dormir leve e compacto', 'OutdoorGear', 89.99, 25),
    ('Lanterna Recarregável', 'Lanterna recarregável de alta potência', 'LightPro', 49.99, 20),
    ('Fogareiro Portátil', 'Fogareiro portátil para camping', 'CampingLife', 39.99, 28),
    ('Colchão Inflável', 'Colchão inflável confortável para camping', 'OutdoorGear', 69.99, 22),
    ('Cadeira Dobrável', 'Cadeira dobrável para camping', 'CampingLife', 29.99, 20),
    ('Kit de Talheres para Camping', 'Kit de talheres compacto para camping', 'OutdoorGear', 29.99, 25),
    ('Bússola', 'Bússola de orientação para atividades ao ar livre', 'OutdoorGear', 24.99, 22),
    ('Garrafa Térmica', 'Garrafa térmica para camping e viagens', 'CampingLife', 24.99, 20),
    ('Bolsa Térmica', 'Bolsa térmica para alimentos e bebidas', 'CampingLife', 29.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (20, 291),
    (20, 292),
    (20, 293),
    (20, 294),
    (20, 295),
    (20, 296),
    (20, 297),
    (20, 298),
    (20, 299),
    (20, 300);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Fraldas Descartáveis Tamanho P', 'Pacote de fraldas descartáveis tamanho P', 'BabyCare', 39.99, 30),
    ('Shampoo para Bebês', 'Shampoo suave para bebês com fórmula hipoalergênica', 'BabyCare', 24.99, 25),
    ('Creme para Assaduras', 'Creme para assaduras com ingredientes naturais', 'BabyCare', 22.99, 20),
    ('Mamadeira Anticólica', 'Mamadeira anticólica com design ergonômico', 'BabyEssentials', 29.99, 28),
    ('Toalhas Umedecidas', 'Pacote de toalhas umedecidas para higiene do bebê', 'BabyEssentials', 9.99, 22),
    ('Babá Eletrônica', 'Babá eletrônica com monitor de áudio e vídeo', 'BabyEssentials', 99.99, 20),
    ('Cadeira de Alimentação', 'Cadeira de alimentação prática e segura para bebês', 'BabyEssentials', 79.99, 25),
    ('Carrinho de Bebê', 'Carrinho de bebê dobrável e resistente', 'BabyEssentials', 249.99, 22),
    ('Chupeta Ortodôntica', 'Chupeta ortodôntica com design ergonômico', 'BabyEssentials', 6.99, 20),
    ('Termômetro Digital', 'Termômetro digital para medição de temperatura', 'BabyEssentials', 29.99, 20);
    
INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (21, 301),
    (21, 302),
    (21, 303),
    (21, 304),
    (21, 305),
    (21, 306),
    (21, 307),
    (21, 308),
    (21, 309),
    (21, 310);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Bexigas Coloridas', 'Pacote com 50 bexigas coloridas para festas', 'PartySupplies', 9.99, 30),
    ('Chapéu de Festa', 'Pacote com 10 chapéus de festa coloridos', 'PartySupplies', 22.99, 25),
    ('Confetes Coloridos', 'Pacote com confetes coloridos para festas', 'PartySupplies', 7.99, 20),
    ('Velas Decorativas', 'Pacote com 20 velas decorativas para bolos', 'PartySupplies', 24.99, 28),
    ('Pratos Descartáveis', 'Pacote com 50 pratos descartáveis para festas', 'PartySupplies', 21.99, 22),
    ('Copos Descartáveis', 'Pacote com 50 copos descartáveis para festas', 'PartySupplies', 9.99, 20),
    ('Guardanapos Decorativos', 'Pacote com 100 guardanapos decorativos para festas', 'PartySupplies', 8.99, 25),
    ('Bandeirinhas Decorativas', 'Pacote com bandeirinhas decorativas para festas', 'PartySupplies', 6.99, 22),
    ('Talheres Descartáveis', 'Pacote com 50 talheres descartáveis para festas', 'PartySupplies', 20.99, 20),
    ('Balões Metalizados', 'Pacote com 10 balões metalizados para festas', 'PartySupplies', 23.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (22, 311),
    (22, 312),
    (22, 313),
    (22, 314),
    (22, 315),
    (22, 316),
    (22, 317),
    (22, 318),
    (22, 319),
    (22, 320);

-- Colecionáveis
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Miniaturas de Carros', 'Miniaturas de carros colecionáveis em escala 1:18', 'CollectiblesInc', 39.99, 30),
    ('Bonecos de Ação', 'Bonecos de ação colecionáveis de personagens famosos', 'CollectiblesInc', 24.99, 25),
    ('Cartas de Pokémon', 'Pacote com 10 cartas de Pokémon para colecionadores', 'CollectiblesInc', 9.99, 20),
    ('Selos Antigos', 'Lote com 20 selos antigos de diferentes países', 'CollectiblesInc', 29.99, 28),
    ('Moedas Raras', 'Moedas raras de diferentes períodos históricos', 'CollectiblesInc', 29.99, 22),
    ('Miniaturas de Aviões', 'Miniaturas de aviões colecionáveis em escala 1:72', 'CollectiblesInc', 34.99, 20),
    ('Figuras de Anime', 'Figuras de anime colecionáveis de séries populares', 'CollectiblesInc', 49.99, 25),
    ('Cédulas Antigas', 'Lote com 10 cédulas antigas de diferentes países', 'CollectiblesInc', 39.99, 22),
    ('Miniaturas de Navios', 'Miniaturas de navios colecionáveis em escala 1:700', 'CollectiblesInc', 59.99, 20),
    ('Action Figures', 'Action figures colecionáveis de personagens de filmes', 'CollectiblesInc', 49.99, 20);
    
INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (23, 321),
    (23, 322),
    (23, 323),
    (23, 324),
    (23, 325),
    (23, 326),
    (23, 327),
    (23, 328),
    (23, 329),
    (23, 330);

-- Suprimentos para Artesanato
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit de Agulhas para Tricô', 'Kit com 12 agulhas de tricô de tamanhos variados', 'CraftSupplies', 9.99, 30),
    ('Tesoura para Artesanato', 'Tesoura de precisão para trabalhos de artesanato', 'CraftSupplies', 8.99, 25),
    ('Cola para Artesanato', 'Cola líquida de secagem rápida para artesanato', 'CraftSupplies', 6.99, 20),
    ('Pincéis para Pintura', 'Conjunto com 10 pincéis de diferentes tamanhos', 'CraftSupplies', 22.99, 28),
    ('Fitas Decorativas', 'Pacote com 5 rolos de fitas decorativas coloridas', 'CraftSupplies', 7.99, 22),
    ('Miçangas Sortidas', 'Pacote com miçangas de diferentes cores e tamanhos', 'CraftSupplies', 9.99, 20),
    ('Linhas para Bordado', 'Conjunto com 10 rolos de linhas para bordado', 'CraftSupplies', 8.99, 25),
    ('Tinta Acrílica', 'Tinta acrílica de secagem rápida para trabalhos de pintura', 'CraftSupplies', 6.99, 22),
    ('Feltro Colorido', 'Pacote com folhas de feltro colorido para artesanato', 'CraftSupplies', 20.99, 20),
    ('Arame para Artesanato', 'Rolo de arame flexível para trabalhos de artesanato', 'CraftSupplies', 23.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (24, 331),
    (24, 332),
    (24, 333),
    (24, 334),
    (24, 335),
    (24, 336),
    (24, 337),
    (24, 338),
    (24, 339),
    (24, 340);

-- Cursos e Treinamentos
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Curso de Fotografia', 'Curso online de fotografia para iniciantes', 'TrainingCenter', 49.99, 30),
    ('Curso de Marketing Digital', 'Curso online de marketing digital com certificado', 'TrainingCenter', 59.99, 25),
    ('Curso de Programação', 'Curso online de programação em linguagem Python', 'TrainingCenter', 39.99, 20),
    ('Curso de Design Gráfico', 'Curso online de design gráfico com aulas práticas', 'TrainingCenter', 49.99, 28),
    ('Curso de Idiomas', 'Curso online de idiomas com material didático incluso', 'TrainingCenter', 69.99, 22),
    ('Curso de Maquiagem', 'Curso online de maquiagem profissional passo a passo', 'TrainingCenter', 39.99, 25),
    ('Curso de Finanças Pessoais', 'Curso online de finanças pessoais para organizar suas finanças', 'TrainingCenter', 29.99, 22),
    ('Curso de Coaching', 'Curso online de coaching para desenvolvimento pessoal e profissional', 'TrainingCenter', 59.99, 20),
    ('Curso de Culinária', 'Curso online de culinária com receitas práticas e saborosas', 'TrainingCenter', 49.99, 20),
    ('Curso de Desenvolvimento Pessoal', 'Curso online de desenvolvimento pessoal com técnicas de autoconhecimento', 'TrainingCenter', 39.99, 28);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (25, 341),
    (25, 342),
    (25, 343),
    (25, 344),
    (25, 345),
    (25, 346),
    (25, 347),
    (25, 348),
    (25, 349),
    (25, 350);

-- Produtos para Cabelos Cacheados
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Cacheados', 'Shampoo específico para limpeza e hidratação de cabelos cacheados', 'CurlsCare', 24.99, 30),
    ('Condicionador para Cabelos Cacheados', 'Condicionador que hidrata e desembaraça cabelos cacheados', 'CurlsCare', 24.99, 25),
    ('Creme de Pentear para Cabelos Cacheados', 'Creme de pentear que define e controla os cachos', 'CurlsCare', 26.99, 20),
    ('Máscara de Tratamento para Cabelos Cacheados', 'Máscara de tratamento intensivo para cabelos cacheados', 'CurlsCare', 29.99, 28),
    ('Óleo Finalizador para Cabelos Cacheados', 'Óleo finalizador que dá brilho e controla o frizz dos cabelos cacheados', 'CurlsCare', 22.99, 22),
    ('Gel para Cabelos Cacheados', 'Gel modelador que fixa os cachos e dá volume aos cabelos cacheados', 'CurlsCare', 20.99, 20),
    ('Ativador de Cachos', 'Ativador de cachos que define e revitaliza os cabelos cacheados', 'CurlsCare', 23.99, 25),
    ('Spray Umidificador para Cabelos Cacheados', 'Spray umidificador que hidrata e refresca os cabelos cacheados', 'CurlsCare', 9.99, 22),
    ('Leave-In para Cabelos Cacheados', 'Leave-in que protege e hidrata os cabelos cacheados', 'CurlsCare', 21.99, 20),
    ('Creme para Pentear para Cabelos Cacheados', 'Creme para pentear que define e controla o volume dos cabelos cacheados', 'CurlsCare', 25.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (26, 351),
    (26, 352),
    (26, 353),
    (26, 354),
    (26, 355),
    (26, 356),
    (26, 357),
    (26, 358),
    (26, 359),
    (26, 360);

-- Moda Plus Size
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vestido Plus Size', 'Vestido longo plus size estampado com decote em V', 'CurvyFashion', 79.99, 30),
    ('Calça Jeans Plus Size', 'Calça jeans plus size com modelagem reta e cintura alta', 'CurvyFashion', 59.99, 25),
    ('Blusa Plus Size', 'Blusa plus size com mangas 3/4 e estampa floral', 'CurvyFashion', 39.99, 20),
    ('Saia Plus Size', 'Saia plus size midi em tecido leve e estampa geométrica', 'CurvyFashion', 49.99, 28),
    ('Camisa Plus Size', 'Camisa plus size com manga longa e botões frontais', 'CurvyFashion', 44.99, 22),
    ('Blazer Plus Size', 'Blazer plus size em tecido de alfaiataria e corte reto', 'CurvyFashion', 69.99, 20),
    ('Macacão Plus Size', 'Macacão plus size pantacourt com estampa tropical', 'CurvyFashion', 89.99, 25),
    ('Shorts Plus Size', 'Shorts plus size em tecido jeans com barra desfiada', 'CurvyFashion', 34.99, 22),
    ('Vestido de Festa Plus Size', 'Vestido de festa plus size longo com detalhes em renda', 'CurvyFashion', 99.99, 20),
    ('Body Plus Size', 'Body plus size com decote transpassado e estampa animal print', 'CurvyFashion', 54.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (27, 361),
    (27, 362),
    (27, 363),
    (27, 364),
    (27, 365),
    (27, 366),
    (27, 367),
    (27, 368),
    (27, 369),
    (27, 370);

-- Produtos para Barba
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit Barba Completo', 'Kit com produtos essenciais para cuidados com a barba', 'BeardMasters', 39.99, 20),
    ('Óleo para Barba', 'Óleo nutritivo para hidratar e amaciar os pelos da barba', 'Gentleman Grooming', 29.99, 30),
    ('Balm para Barba', 'Balm hidratante para modelar e dar forma à barba', 'BarbaStyle', 24.99, 25),
    ('Shampoo para Barba', 'Shampoo suave para limpeza dos pelos da barba', 'BarbaFresh', 22.99, 25),
    ('Pente para Barba', 'Pente de madeira para desembaraçar e pentear a barba', 'WoodenBeard', 9.99, 40),
    ('Tesoura para Barba', 'Tesoura de precisão para aparar e modelar os pelos da barba', 'SharpGroom', 26.99, 20),
    ('Cera para Bigode', 'Cera modeladora para fixação e estilização do bigode', 'MustacheWax', 21.99, 20),
    ('Condicionador para Barba', 'Condicionador hidratante para deixar a barba macia e brilhante', 'BeardCare', 27.99, 25),
    ('Bálsamo pós-barba', 'Bálsamo refrescante para acalmar a pele após o barbear', 'CoolAfterShave', 9.99, 30),
    ('Escova para Barba', 'Escova de cerdas naturais para pentear e alinhar os pelos da barba', 'BeardBrush', 23.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (28, 371),
    (28, 372),
    (28, 373),
    (28, 374),
    (28, 375),
    (28, 376),
    (28, 377),
    (28, 378),
    (28, 379),
    (28, 380);

-- Produtos para Piscina
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Boia Inflável para Piscina', 'Boia divertida e colorida para aproveitar na piscina', 'AquaFun', 29.99, 50),
    ('Protetor Solar FPS 50', 'Protetor solar resistente à água para proteção na piscina', 'SunGuard', 22.99, 30),
    ('Toalha de Praia', 'Toalha macia e absorvente para levar à beira da piscina', 'BeachLife', 29.99, 40),
    ('Óculos de Natação', 'Óculos com vedação perfeita para natação na piscina', 'SwimPro', 24.99, 20),
    ('Bolsa Térmica para Piscina', 'Bolsa com isolamento térmico para armazenar alimentos e bebidas', 'CoolPool', 24.99, 25),
    ('Chapéu de Sol', 'Chapéu com proteção UV para aproveitar a piscina sem se preocupar', 'SunShield', 9.99, 25),
    ('Prancha de Natação', 'Prancha flutuante para treinar e se divertir na piscina', 'AquaBoard', 27.99, 30),
    ('Escorregador Inflável', 'Escorregador inflável para diversão garantida na piscina', 'SplashFun', 39.99, 20),
    ('Rede de Vôlei para Piscina', 'Rede de vôlei resistente para partidas animadas na piscina', 'PoolSports', 54.99, 5),
    ('Tapete Inflável para Piscina', 'Tapete inflável para relaxar e tomar sol na piscina', 'SunLounger', 34.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (29, 381),
    (29, 382),
    (29, 383),
    (29, 384),
    (29, 385),
    (29, 386),
    (29, 387),
    (29, 388),
    (29, 389),
    (29, 390);

-- Bolsas e Malas
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Mochila Esportiva', 'Mochila espaçosa e resistente para atividades esportivas', 'SportGear', 49.99, 30),
    ('Bolsa de Viagem Grande', 'Bolsa de viagem com amplo espaço para suas aventuras', 'TravelPro', 79.99, 20),
    ('Mala de Rodinhas', 'Mala com rodinhas para facilitar o transporte em viagens', 'EasyTravel', 99.99, 25),
    ('Bolsa Térmica', 'Bolsa térmica para manter alimentos e bebidas na temperatura ideal', 'CoolBag', 24.99, 50),
    ('Mochila Casual', 'Mochila prática e estilosa para uso no dia a dia', 'UrbanStyle', 39.99, 40),
    ('Bolsa de Ombro', 'Bolsa compacta e elegante para complementar seu visual', 'ChicAccessories', 29.99, 30),
    ('Mochila de Couro', 'Mochila de couro durável e sofisticada para quem busca estilo', 'LeatherCraft', 89.99, 20),
    ('Mala de Bordo', 'Mala de bordo compacta e prática para viagens curtas', 'TravelLight', 69.99, 25),
    ('Mala para Notebook', 'Mala com compartimento acolchoado para transporte seguro do notebook', 'TechTravel', 54.99, 25),
    ('Mochila Antifurto', 'Mochila com sistema antifurto para proteger seus pertences', 'SecurePack', 59.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (30, 391),
    (30, 392),
    (30, 393),
    (30, 394),
    (30, 395),
    (30, 396),
    (30, 397),
    (30, 398),
    (30, 399),
    (30, 400);

-- Acessórios para Carros
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Carregador Veicular USB', 'Carregador veicular com portas USB para carregar seus dispositivos', 'ChargeDrive', 9.99, 50),
    ('Suporte para Celular', 'Suporte ajustável para celular, ideal para uso em carros', 'DriveMate', 24.99, 30),
    ('Tapete Automotivo', 'Tapete resistente e durável para proteção do assoalho do carro', 'AutoShield', 24.99, 40),
    ('Organizador para Carro', 'Organizador com vários compartimentos para armazenar objetos no carro', 'CarCaddy', 29.99, 25),
    ('Cabo Auxiliar P2', 'Cabo auxiliar P2 para conexão de dispositivos de áudio no carro', 'AudioLink', 7.99, 40),
    ('Capa para Volante', 'Capa protetora e confortável para o volante do carro', 'SteeringCover', 21.99, 25),
    ('Kit Limpeza Automotiva', 'Kit com produtos para limpeza e cuidado do carro', 'AutoClean', 29.99, 20),
    ('Aromatizante para Carro', 'Aromatizante com fragrância agradável para deixar o carro perfumado', 'CarFresh', 4.99, 50),
    ('Cabo de Carga para Bateria', 'Cabo de carga para auxiliar na partida de bateria do carro', 'PowerBoost', 26.99, 20),
    ('Cadeirinha Infantil para Carro', 'Cadeirinha de segurança para transporte de crianças no carro', 'SafeRide', 89.99, 5);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (31, 401),
    (31, 402),
    (31, 403),
    (31, 404),
    (31, 405),
    (31, 406),
    (31, 407),
    (31, 408),
    (31, 409),
    (31, 410);


-- Produtos para Unhas
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit Manicure Profissional', 'Kit completo com acessórios para manicure profissional', 'ProNails', 49.99, 20),
    ('Esmalte de Longa Duração', 'Esmalte de alta qualidade e longa duração para unhas perfeitas', 'ColorStay', 9.99, 30),
    ('Alicate de Cutícula', 'Alicate de precisão para remoção de cutículas', 'CuticleCare', 22.99, 25),
    ('Base Fortalecedora de Unhas', 'Base fortalecedora para unhas fracas e quebradiças', 'NailStrength', 7.99, 25),
    ('Removedor de Esmalte', 'Removedor de esmalte eficiente e suave para unhas', 'GentleRemover', 4.99, 40),
    ('Lixa para Unhas', 'Lixa de qualidade para modelar e dar acabamento às unhas', 'PerfectShape', 3.99, 20),
    ('Top Coat', 'Finalizador de esmalte para maior durabilidade e brilho', 'ShineOn', 6.99, 20),
    ('Secante de Esmalte', 'Secante de esmalte em spray para secagem rápida', 'QuickDry', 8.99, 25),
    ('Kit Carimbo para Unhas', 'Kit com carimbos e placas para decoração de unhas', 'StampArt', 24.99, 30),
    ('Adesivos para Unhas', 'Adesivos decorativos para unhas com diversos designs', 'NailStickers', 5.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (32, 411),
    (32, 412),
    (32, 413),
    (32, 414),
    (32, 415),
    (32, 416),
    (32, 417),
    (32, 418),
    (32, 419),
    (32, 420);

-- Moda Fitness
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Legging Esportiva', 'Legging confortável e flexível para prática de exercícios físicos', 'FlexFit', 34.99, 50),
    ('Top Esportivo', 'Top de suporte para atividades físicas de impacto moderado', 'ActiveMotion', 24.99, 30),
    ('Camiseta Dry Fit', 'Camiseta de tecido respirável e de rápida secagem para esportes', 'DrySport', 29.99, 40),
    ('Shorts de Corrida', 'Shorts leve e confortável para corridas e atividades aeróbicas', 'RunLite', 24.99, 25),
    ('Tênis de Academia', 'Tênis com amortecimento e estabilidade para treinos na academia', 'GymPro', 59.99, 40),
    ('Regata Esportiva', 'Regata solta e fresca para treinos intensos e exercícios ao ar livre', 'CoolFit', 27.99, 30),
    ('Meia Esportiva', 'Meia acolchoada e respirável para uso em atividades físicas', 'ActiveSock', 7.99, 40),
    ('Jaqueta Corta-Vento', 'Jaqueta leve e resistente ao vento para proteção durante atividades ao ar livre', 'WindGuard', 49.99, 20),
    ('Calça Legging Estampada', 'Calça legging estampada para compor looks estilosos na academia', 'PrintFit', 29.99, 20),
    ('Sapatilha de Pilates', 'Sapatilha flexível e antiderrapante para prática de pilates e ioga', 'PilatesFlex', 29.99, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (33, 421),
    (33, 422),
    (33, 423),
    (33, 424),
    (33, 425),
    (33, 426),
    (33, 427),
    (33, 428),
    (33, 429),
    (33, 430);

-- Suprimentos para Pet Shop
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Ração para Cães', 'Ração premium para cães adultos de raças médias e grandes', 'PrimeDog', 49.99, 50),
    ('Areia Sanitária para Gatos', 'Areia higiênica absorvente para bandeja de gatos', 'CleanPaws', 9.99, 30),
    ('Brinquedo para Cães', 'Brinquedo resistente e interativo para cães de médio e grande porte', 'PlayFetch', 24.99, 40),
    ('Coleira Antipulgas', 'Coleira ajustável com ação repelente e antipulgas para cães e gatos', 'FleaShield', 22.99, 25),
    ('Comedouro Automático', 'Comedouro com dispenser automático de ração para cães e gatos', 'FeedWell', 29.99, 40),
    ('Shampoo para Cães e Gatos', 'Shampoo suave e hipoalergênico para higiene de cães e gatos', 'GentleCare', 7.99, 25),
    ('Tapete Higiênico', 'Tapete absorvente para adestramento e higiene de cães', 'PottyPad', 6.99, 40),
    ('Escova para Cães e Gatos', 'Escova de cerdas macias para cuidados diários com a pelagem', 'GroomPro', 9.99, 20),
    ('Brinquedo para Gatos', 'Brinquedo interativo e estimulante para gatos de todas as idades', 'CatPlay', 8.99, 25),
    ('Cama para Cães e Gatos', 'Cama confortável e aconchegante para cães e gatos de pequeno porte', 'CozyPet', 24.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (34, 431),
    (34, 432),
    (34, 433),
    (34, 434),
    (34, 435),
    (34, 436),
    (34, 437),
    (34, 438),
    (34, 439),
    (34, 440);

-- Produtos para Churrasco
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Churrasqueira Portátil', 'Churrasqueira compacta e fácil de transportar para churrascos ao ar livre', 'GrillMate', 59.99, 50),
    ('Kit Churrasco', 'Kit completo com utensílios para churrasco', 'BBQMaster', 34.99, 30),
    ('Espeto Giratório', 'Espeto giratório automático para assar carnes de forma uniforme', 'Rotisserie', 39.99, 40),
    ('Acendedor de Carvão', 'Acendedor elétrico para carvão, facilitando o acendimento da churrasqueira', 'FireStart', 24.99, 25),
    ('Grelha para Churrasco', 'Grelha resistente e de fácil limpeza para assar carnes no churrasco', 'GrillPro', 29.99, 40),
    ('Maleta de Facas para Churrasco', 'Maleta com facas de alta qualidade para corte de carnes', 'KnifeSet', 59.99, 25),
    ('Tábua de Corte para Churrasco', 'Tábua de corte de madeira maciça para preparação de carnes', 'CuttingBoard', 29.99, 20),
    ('Churrasqueira Elétrica', 'Churrasqueira elétrica compacta e prática para uso em ambientes internos', 'ElectricGrill', 49.99, 50),
    ('Molho Barbecue', 'Molho barbecue com sabor defumado para realçar o sabor das carnes', 'SmokyBBQ', 4.99, 20),
    ('Avental para Churrasco', 'Avental resistente e ajustável para proteção durante o preparo do churrasco', 'GrillGuard', 9.99, 5);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (35, 441),
    (35, 442),
    (35, 443),
    (35, 444),
    (35, 445),
    (35, 446),
    (35, 447),
    (35, 448),
    (35, 449),
    (35, 450);

-- Produtos para Casa de Praia
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Cadeira de Praia', 'Cadeira dobrável e leve para aproveitar a praia com conforto', 'BeachComfort', 24.99, 50),
    ('Guarda-Sol', 'Guarda-sol grande e resistente para proteção contra o sol na praia', 'SunShield', 39.99, 30),
    ('Cooler Térmico', 'Cooler térmico com alça para armazenar bebidas e alimentos gelados', 'IceCool', 49.99, 40),
    ('Toalha de Praia', 'Toalha macia e absorvente para uso na praia e na piscina', 'SeaBreeze', 29.99, 25),
    ('Bolsa Térmica', 'Bolsa térmica com alça ajustável para transporte de alimentos e bebidas', 'CoolCarry', 24.99, 40),
    ('Chinelo Slide', 'Chinelo slide confortável e resistente para uso na praia e no dia a dia', 'BeachSlide', 9.99, 25),
    ('Óculos de Sol', 'Óculos de sol com proteção UV para estilo e proteção dos olhos', 'SunShades', 29.99, 20),
    ('Canga de Praia', 'Canga leve e estilosa para usar na praia e como saída de praia', 'BeachWrap', 26.99, 20),
    ('Chapéu de Praia', 'Chapéu de aba larga para proteção do rosto e cabeça contra o sol', 'SunHat', 22.99, 25),
    ('Kit Praia Infantil', 'Kit com baldinho, pazinha, rastelo e formas para brincadeiras na praia', 'BeachFun', 9.99, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (36, 451),
    (36, 452),
    (36, 453),
    (36, 454),
    (36, 455),
    (36, 456),
    (36, 457),
    (36, 458),
    (36, 459),
    (36, 460);

-- Produtos para Casa de Campo
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Rede de Descanso', 'Rede de descanso confortável para aproveitar momentos de relaxamento na casa de campo', 'Hammock', 34.99, 50),
    ('Cadeira de Camping', 'Cadeira dobrável e resistente para uso em acampamentos e atividades ao ar livre', 'CampComfort', 24.99, 30),
    ('Barraca de Camping', 'Barraca resistente e fácil de montar para acomodação durante acampamentos', 'CampPro', 79.99, 40),
    ('Lanterna Portátil', 'Lanterna portátil com luz intensa e alça para uso em ambientes sem eletricidade', 'LightBeam', 24.99, 25),
    ('Canivete Multiuso', 'Canivete compacto com múltiplas ferramentas para uso em atividades ao ar livre', 'Outdoorsman', 29.99, 40),
    ('Kit Churrasco para Camping', 'Kit completo com utensílios de churrasco para uso em acampamentos', 'CampBBQ', 39.99, 25),
    ('Saco de Dormir', 'Saco de dormir confortável e aquecido para noites em acampamentos', 'SleepWell', 59.99, 20),
    ('Fogareiro Portátil', 'Fogareiro compacto e portátil para preparo de alimentos em acampamentos', 'CampStove', 29.99, 20),
    ('Colchonete Inflável', 'Colchonete inflável para proporcionar conforto durante o sono em acampamentos', 'AirRest', 24.99, 20),
    ('Kit Sobrevivência', 'Kit com itens essenciais para situações de emergência e sobrevivência', 'SurvivalKit', 49.99, 5);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (37, 461),
    (37, 462),
    (37, 463),
    (37, 464),
    (37, 465),
    (37, 466),
    (37, 467),
    (37, 468),
    (37, 469),
    (37, 470);

-- Produtos para Home Office
INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Mesa de Escritório', 'Mesa de escritório espaçosa e resistente para organização no home office', 'OfficePro', 299.99, 50),
    ('Cadeira Ergonômica', 'Cadeira ergonômica com ajustes de altura e apoio lombar para conforto no trabalho', 'ErgoComfort', 249.99, 30),
    ('Monitor LED', 'Monitor LED de alta definição para visualização nítida de documentos e imagens', 'ViewSight', 299.99, 40),
    ('Teclado sem Fio', 'Teclado sem fio com layout confortável e conectividade Bluetooth', 'WirelessType', 49.99, 25),
    ('Mouse Óptico', 'Mouse óptico preciso e ergonômico para uso prolongado no trabalho', 'ErgoMouse', 29.99, 40),
    ('Luminária de Mesa', 'Luminária de mesa com ajuste de intensidade e temperatura de cor', 'DeskLight', 29.99, 25),
    ('Organizador de Cabos', 'Organizador de cabos para manter a mesa do home office organizada', 'CableTidy', 9.99, 40),
    ('Fone de Ouvido com Microfone', 'Fone de ouvido com microfone integrado para chamadas e reuniões online', 'SoundCall', 39.99, 20),
    ('Suporte para Notebook', 'Suporte ergonômico para notebook, facilitando a visualização e digitação', 'NoteStand', 24.99, 25),
    ('Quadro de Aviso Magnético', 'Quadro de avisos magnético para anotações e lembretes no home office', 'MemoBoard', 22.99, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (38, 471),
    (38, 472),
    (38, 473),
    (38, 474),
    (38, 475),
    (38, 476),
    (38, 477),
    (38, 478),
    (38, 479),
    (38, 480);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Cadeira de Rodas Infantil', 'Cadeira de rodas projetada para crianças com necessidades especiais.', 'AdaptKids', 799.90, 20),
    ('Brinquedo Sensorial', 'Brinquedo com estímulos sensoriais para crianças com autismo.', 'SensoryPlay', 59.90, 20),
    ('Livro em Braille', 'Livro infantil com texto em braille para crianças com deficiência visual.', 'BrailleBooks', 39.90, 25),
    ('Mochila Adaptada', 'Mochila ergonômica com suporte para cadeira de rodas para crianças com mobilidade reduzida.', 'EasyMobility', 229.90, 8),
    ('Jogo de Estimulação Cognitiva', 'Jogo educativo para estimular o desenvolvimento cognitivo de crianças com necessidades especiais.', 'BrainBoost', 49.90, 22),
    ('Óculos com Filtro de Luz Azul', 'Óculos com filtro de luz azul para crianças com sensibilidade à luz.', 'BlueShield', 99.90, 28),
    ('Andador Adaptado', 'Andador com suporte para auxiliar crianças com dificuldades de locomoção.', 'MoveAssist', 249.90, 5),
    ('Tapete de Atividades Sensoriais', 'Tapete com texturas e estímulos sensoriais para desenvolver habilidades motoras em crianças com deficiências.', 'SensoryMat', 89.90, 20),
    ('Cadeira Adaptada para Alimentação', 'Cadeira de alimentação com suporte e ajustes para crianças com necessidades especiais.', 'EatWell', 279.90, 7),
    ('Brinquedo Inclusivo', 'Brinquedo inclusivo com recursos adaptados para crianças com diferentes habilidades.', 'InclusiveToys', 69.90, 25);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (39, 481),
    (39, 482),
    (39, 483),
    (39, 484),
    (39, 485),
    (39, 486),
    (39, 487),
    (39, 488),
    (39, 489),
    (39, 490);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Capa Protetora para iPhone X', 'Capa de proteção resistente para o modelo iPhone X.', 'TechGuard', 29.90, 50),
    ('Carregador Portátil 10000mAh', 'Carregador de bateria portátil com capacidade de 10000mAh.', 'PowerOn', 79.90, 20),
    ('Fone de Ouvido Bluetooth', 'Fone de ouvido sem fio com conexão Bluetooth.', 'WirelessSound', 249.90, 30),
    ('Película de Vidro para Samsung Galaxy S20', 'Película protetora de vidro temperado para o modelo Samsung Galaxy S20.', 'CrystalShield', 29.90, 200),
    ('Suporte Veicular Magnético', 'Suporte magnético para fixação de celular em veículos.', 'DriveMount', 39.90, 40),
    ('Carregador sem Fio Qi', 'Carregador sem fio compatível com a tecnologia Qi.', 'WirelessCharge', 59.90, 25),
    ('Pop Socket', 'Suporte de dedo para celular com design estilizado.', 'PopStyle', 9.90, 80),
    ('Cabo USB-C para iPhone', 'Cabo de carregamento USB-C compatível com dispositivos iPhone.', 'iCharge', 24.90, 60),
    ('Lente Externa para Celular', 'Lente externa para melhorar a qualidade das fotos tiradas com o celular.', 'PhotoLens', 69.90, 25),
    ('Capa Personalizada para Samsung Galaxy A50', 'Capa de proteção personalizada para o modelo Samsung Galaxy A50.', 'CustomCase', 34.90, 35);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (40, 491),
    (40, 492),
    (40, 493),
    (40, 494),
    (40, 495),
    (40, 496),
    (40, 497),
    (40, 498),
    (40, 499),
    (40, 500);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit de Bicos de Confeitar', 'Conjunto de bicos de confeitar para decoração de bolos e doces.', 'SweetDecor', 39.90, 50),
    ('Forma de Silicone para Cupcake', 'Forma de silicone com cavidades para assar cupcakes.', 'BakeMaster', 29.90, 30),
    ('Corante Alimentício em Gel', 'Corante alimentício em gel com diversas cores para colorir massas e coberturas.', 'RainbowColors', 9.90, 200),
    ('Espátula de Confeiteiro', 'Espátula de aço inox para auxiliar no trabalho de confeitaria.', 'CakeCraft', 24.90, 80),
    ('Tapete de Silicone para Decoração', 'Tapete de silicone com desenhos para auxiliar na decoração de bolos.', 'DesignMat', 24.90, 40),
    ('Mistura para Bolo de Chocolate', 'Mistura pronta para preparo de bolo de chocolate.', 'ChocoDelight', 7.90, 200),
    ('Pasta Americana Branca', 'Pasta americana branca para cobertura e modelagem de bolos.', 'SugarArt', 29.90, 50),
    ('Conjunto de Cortadores de Biscoito', 'Conjunto com diversos cortadores de biscoito em formatos variados.', 'CookieCutter', 22.90, 250),
    ('Glitter Comestível', 'Glitter comestível para decorar bolos e doces.', 'EdibleGlitz', 6.90, 200),
    ('Bico Perlê', 'Bico de confeitar Perlê para criar detalhes em bolos e cupcakes.', 'PearlTip', 8.90, 70);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (41, 501),
    (41, 502),
    (41, 503),
    (41, 504),
    (41, 505),
    (41, 506),
    (41, 507),
    (41, 508),
    (41, 509),
    (41, 510);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Tinta para Tatuagem Preta', 'Tinta preta para uso profissional em tatuagem.', 'InkMaster', 49.90, 50),
    ('Agulhas para Tatuagem RL', 'Agulhas para tatuagem modelo Round Liner (RL).', 'TattooPro', 22.90, 200),
    ('Máquina de Tatuagem Profissional', 'Máquina de tatuagem profissional para traços e sombras.', 'ArtInk', 249.90, 20),
    ('Batoque Descartável', 'Batoque descartável para armazenar tinta durante o procedimento de tatuagem.', 'InkHolder', 6.90, 200),
    ('Biqueira Descartável', 'Biqueira descartável esterilizada para uso em tatuagem.', 'TipGuard', 8.90, 250),
    ('Grip para Tatuagem', 'Grip de alumínio para encaixe na máquina de tatuagem.', 'ErgoGrip', 29.90, 50),
    ('Luvas Descartáveis', 'Luvas descartáveis para proteção durante o procedimento de tatuagem.', 'SafeGlove', 29.90, 80),
    ('Balm para Cicatrização de Tatuagem', 'Balm para auxiliar na cicatrização e hidratação de tatuagens.', 'InkCare', 26.90, 60),
    ('Stencil para Tatuagem', 'Stencil para transferência de desenhos para a pele antes da tatuagem.', 'SkinTrace', 9.90, 200),
    ('Tinta para Tatuagem Colorida', 'Conjunto de tintas coloridas para uso profissional em tatuagem.', 'ColorWorld', 89.90, 30);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (42, 511),
    (42, 512),
    (42, 513),
    (42, 514),
    (42, 515),
    (42, 516),
    (42, 517),
    (42, 518),
    (42, 519),
    (42, 520);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Conjunto de Pincéis Artísticos', 'Conjunto com pincéis de diferentes tamanhos para pintura artística.', 'ArtBrush', 29.90, 50),
    ('Tinta Acrílica', 'Tinta acrílica de alta qualidade para pintura em tela e outros materiais.', 'AcrylicArt', 22.90, 200),
    ('Easel de Madeira', 'Easel de madeira ajustável para apoio de tela durante a pintura.', 'WoodCraft', 49.90, 30),
    ('Paleta de Mistura', 'Paleta de mistura de tintas com várias divisórias.', 'MixPalette', 9.90, 80),
    ('Tela para Pintura', 'Tela em branco para pintura disponível em diversos tamanhos.', 'ArtCanvas', 29.90, 40),
    ('Conjunto de Giz Pastel', 'Conjunto com giz pastel de diversas cores para técnicas de pintura.', 'SoftPastel', 24.90, 200),
    ('Esfuminho', 'Esfuminho para efeitos de sombreamento e esfumado na pintura.', 'BlendTool', 6.90, 50),
    ('Pigmento Metálico', 'Pigmento metálico para dar efeitos brilhantes e metálicos na pintura.', 'MetallicShine', 29.90, 250),
    ('Estojo de Aquarela', 'Estojo com tintas aquarela e pincel para pintura com efeitos de transparência.', 'WatercolorSet', 24.90, 200),
    ('Conjunto de Tintas a Óleo', 'Conjunto com tintas a óleo em tubos para pintura artística.', 'OilPaint', 39.90, 70);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (43, 521),
    (43, 522),
    (43, 523),
    (43, 524),
    (43, 525),
    (43, 526),
    (43, 527),
    (43, 528),
    (43, 529),
    (43, 530);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vara de Pesca Telescópica', 'Vara de pesca telescópica em fibra de carbono.', 'FishMaster', 89.90, 50),
    ('Carretilha de Pesca', 'Carretilha de pesca com sistema de freio e recolhimento suave.', 'ReelPro', 249.90, 30),
    ('Iscas Artificiais', 'Conjunto de iscas artificiais para pesca em água doce.', 'LureMax', 29.90, 200),
    ('Linhas de Pesca', 'Linha de pesca resistente e durável para diversas modalidades.', 'FishLine', 9.90, 200),
    ('Anzol para Pesca', 'Anzol resistente e afiado para diversas espécies de peixes.', 'HookMaster', 6.90, 300),
    ('Caixa de Pesca', 'Caixa de pesca com compartimentos para armazenar acessórios.', 'TackleBox', 29.90, 80),
    ('Bóia para Pesca', 'Bóia de pesca para sinalizar quando o peixe ataca a isca.', 'FloatMaster', 4.90, 250),
    ('Alicate de Pesca', 'Alicate de pesca resistente para remoção de anzóis.', 'FishTool', 22.90, 200),
    ('Chumbada para Pesca', 'Chumbada de pesca para ajudar no arremesso da isca.', 'WeightCast', 7.90, 200),
    ('Capa de Proteção para Varas', 'Capa protetora para varas de pesca durante o transporte.', 'RodCover', 24.90, 80);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (44, 531),
    (44, 532),
    (44, 533),
    (44, 534),
    (44, 535),
    (44, 536),
    (44, 537),
    (44, 538),
    (44, 539),
    (44, 540);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Camiseta de Algodão Orgânico', 'Camiseta feita de algodão orgânico, sustentável e ecologicamente correto.', 'EcoFashion', 39.90, 50),
    ('Calça Jeans Reciclada', 'Calça jeans produzida a partir de materiais reciclados, contribuindo para a sustentabilidade.', 'ReGenDenim', 89.90, 30),
    ('Vestido de Bambu', 'Vestido feito de fibra de bambu, um material natural, macio e sustentável.', 'BambooChic', 79.90, 40),
    ('Bolsa Ecológica', 'Bolsa feita de tecido reciclado, uma opção sustentável para carregar seus pertences.', 'EcoBag', 29.90, 80),
    ('Sapatos Veganos', 'Sapatos produzidos sem o uso de qualquer material de origem animal, respeitando a vida dos animais.', 'VeggieSteps', 229.90, 50),
    ('Jaqueta de PET Reciclado', 'Jaqueta feita a partir de garrafas PET recicladas, uma alternativa sustentável para o vestuário.', 'EcoJacket', 99.90, 70),
    ('Blusa de Linho', 'Blusa confeccionada em linho, uma fibra natural e sustentável.', 'LinenEssence', 49.90, 200),
    ('Acessórios de Bambu', 'Acessórios como colares, pulseiras e brincos feitos de bambu, uma opção ecológica e elegante.', 'BambooAccessories', 29.90, 200),
    ('Camisa Social Sustentável', 'Camisa social produzida com tecidos sustentáveis, alinhando elegância e responsabilidade ambiental.', 'EcoDressShirt', 69.90, 250),
    ('Óculos de Sol Ecológicos', 'Óculos de sol fabricados com materiais reciclados, uma escolha consciente para proteger seus olhos e o planeta.', 'EcoEyewear', 79.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (45, 541),
    (45, 542),
    (45, 543),
    (45, 544),
    (45, 545),
    (45, 546),
    (45, 547),
    (45, 548),
    (45, 549),
    (45, 550);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Suplemento Vitamínico para Cães', 'Suplemento vitamínico em forma de tabletes para melhorar a saúde e bem-estar dos cães.', 'VitaPet', 39.90, 50),
    ('Ração Especial para Gatos', 'Ração formulada especialmente para atender às necessidades nutricionais dos gatos.', 'GourmetFeline', 89.90, 30),
    ('Comedouro Automático', 'Comedouro automático para cães e gatos, facilitando a alimentação e proporcionando praticidade.', 'AutoFeed', 79.90, 40),
    ('Brinquedo Interativo para Roedores', 'Brinquedo interativo com labirinto para entreter e estimular a inteligência de roedores.', 'SmartPet', 29.90, 80),
    ('Suplemento para Cavalos', 'Suplemento nutricional para melhorar a saúde e desempenho de cavalos.', 'EquinePower', 229.90, 50),
    ('Aquário Completo', 'Aquário completo com todos os acessórios necessários para criar um ambiente saudável para peixes.', 'AquaWorld', 299.90, 70),
    ('Cama para Pets', 'Cama confortável e acolhedora para cães e gatos descansarem com todo o conforto.', 'CozyPet', 59.90, 200),
    ('Brinquedo de Corda para Cães', 'Brinquedo de corda resistente para cães se divertirem e exercitarem a mandíbula.', 'RopePlay', 29.90, 200),
    ('Shampoo Hipoalergênico para Pets', 'Shampoo suave e hipoalergênico para banho de cães e gatos com pele sensível.', 'GentleCare', 24.90, 250),
    ('Coleira Antipulgas e Carrapatos', 'Coleira eficaz no combate a pulgas e carrapatos em cães e gatos.', 'TickGuard', 49.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (46, 551),
    (46, 552),
    (46, 553),
    (46, 554),
    (46, 555),
    (46, 556),
    (46, 557),
    (46, 558),
    (46, 559),
    (46, 560);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Ring Light', 'Ring light com ajuste de intensidade para iluminar vídeos e fotos nas redes sociais.', 'GlamLight', 99.90, 50),
    ('Microfone de Lapela', 'Microfone de lapela com excelente qualidade de áudio para gravações de vídeos.', 'ProSound', 59.90, 30),
    ('Estabilizador para Celular', 'Estabilizador de imagem para celulares, ideal para gravar vídeos estáveis e profissionais.', 'SteadyShot', 249.90, 40),
    ('Tripé Flexível', 'Tripé flexível e ajustável para posicionar o celular em diferentes ângulos durante as gravações.', 'FlexTripod', 29.90, 80),
    ('Câmera Instantânea', 'Câmera instantânea para tirar fotos e compartilhá-las rapidamente nas redes sociais.', 'SnapShot', 299.90, 50),
    ('Kit de Iluminação', 'Kit de iluminação com lâmpadas e suportes para criar um ambiente adequado para vídeos e fotos.', 'LightPro', 229.90, 70),
    ('Microfone de Mesa', 'Microfone de mesa com alto desempenho e clareza de áudio para transmissões ao vivo.', 'StudioSound', 79.90, 200),
    ('Softbox', 'Softbox para proporcionar uma iluminação suave e profissional em estúdios de gravação.', 'SoftPro', 49.90, 200),
    ('Tripé Profissional', 'Tripé profissional resistente e estável para suportar câmeras e equipamentos de gravação.', 'ProTripod', 69.90, 250),
    ('Microfone USB', 'Microfone de alta qualidade com conexão USB para gravações de áudio com excelente nitidez.', 'USBAudio', 89.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (47, 561),
    (47, 562),
    (47, 563),
    (47, 564),
    (47, 565),
    (47, 566),
    (47, 567),
    (47, 568),
    (47, 569),
    (47, 570);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit Ferramentas de Jardinagem', 'Kit completo de ferramentas de jardinagem, incluindo pá, rastelo, tesoura de poda e muito mais.', 'GardenPro', 79.90, 50),
    ('Vaso Autoirrigável', 'Vaso com sistema de autoirrigação, ideal para manter as plantas saudáveis por mais tempo.', 'SelfGrow', 39.90, 30),
    ('Fertilizante Orgânico', 'Fertilizante orgânico rico em nutrientes para promover o crescimento saudável das plantas.', 'EcoGarden', 29.90, 40),
    ('Tesoura de Poda', 'Tesoura de poda afiada e precisa para realizar cortes precisos em galhos e folhagens.', 'GreenCuts', 29.90, 80),
    ('Regador Automático', 'Regador automático com timer programável para garantir a rega adequada das plantas.', 'AquaTime', 49.90, 50),
    ('Adubo Solúvel', 'Adubo solúvel de liberação lenta para nutrir as plantas de forma eficiente e duradoura.', 'NutriGrow', 24.90, 70),
    ('Luvas de Jardinagem', 'Luvas resistentes e impermeáveis para proteger as mãos durante atividades de jardinagem.', 'GloveGuard', 9.90, 200),
    ('Sementes de Flores', 'Kit com variedades de sementes de flores para plantio e cultivo em jardins e vasos.', 'BloomSeeds', 22.90, 200),
    ('Pá de Jardinagem', 'Pá de jardinagem resistente e durável para cavar e transplantar mudas e plantas.', 'DigPro', 29.90, 250),
    ('Estufa para Mudas', 'Estufa compacta para germinação e proteção de mudas e sementes durante o cultivo.', 'SeedHouse', 69.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (48, 571),
    (48, 572),
    (48, 573),
    (48, 574),
    (48, 575),
    (48, 576),
    (48, 577),
    (48, 578),
    (48, 579),
    (48, 580);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vestido Vintage', 'Vestido estilo vintage com estampa retrô e corte clássico, perfeito para looks femininos.', 'RetroChic', 229.90, 50),
    ('Camisa Xadrez', 'Camisa xadrez em estilo vintage, ideal para compor um visual despojado e retrô.', 'VintagePlaid', 79.90, 30),
    ('Saia de Cintura Alta', 'Saia de cintura alta em modelagem vintage, trazendo um toque feminino e elegante ao visual.', 'HighWaist', 49.90, 40),
    ('Jaqueta de Couro Vintage', 'Jaqueta de couro legítimo em estilo vintage, conferindo um ar de rebeldia e atitude.', 'RetroLeather', 299.90, 80),
    ('Óculos de Sol Retro', 'Óculos de sol com design retro, proporcionando um visual estiloso e cheio de personalidade.', 'VintageShades', 69.90, 50),
    ('Calça Jeans Vintage', 'Calça jeans em estilo vintage, com lavagem e detalhes que remetem às décadas passadas.', 'DenimClassics', 89.90, 70),
    ('Bolsa Vintage', 'Bolsa em estilo vintage, com acabamento em couro sintético e detalhes retro.', 'RetroBag', 39.90, 200),
    ('Sapato Oxford', 'Sapato oxford em estilo vintage, combinando conforto e elegância para qualquer ocasião.', 'VintageSteps', 59.90, 200),
    ('Blusa Cropped Vintage', 'Blusa cropped com inspiração vintage, trazendo um toque de sensualidade e estilo.', 'CuteCrops', 29.90, 250),
    ('Lenço Estampado', 'Lenço estampado em estilo vintage, perfeito para dar um toque especial aos looks.', 'RetroScarf', 29.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (49, 581),
    (49, 582),
    (49, 583),
    (49, 584),
    (49, 585),
    (49, 586),
    (49, 587),
    (49, 588),
    (49, 589),
    (49, 590);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shape de Skate', 'Shape de skate em madeira resistente, ideal para manobras e desempenho nas pistas.', 'ProSkate', 99.90, 50),
    ('Truck para Skate', 'Truck de alta qualidade para skate, garantindo estabilidade e controle nas manobras.', 'SkateTruck', 49.90, 30),
    ('Rodas para Skate', 'Rodas duráveis e aderentes para skate, proporcionando uma ótima performance nas pistas.', 'SpeedWheels', 29.90, 40),
    ('Rolamentos para Skate', 'Rolamentos de alta precisão para skate, assegurando velocidade e suavidade nas manobras.', 'SmoothRide', 29.90, 80),
    ('Capacete de Proteção', 'Capacete de proteção para skate, oferecendo segurança durante as manobras e quedas.', 'SkateSafe', 39.90, 50),
    ('Joelheira para Skate', 'Joelheira acolchoada e ajustável para proteção durante as manobras de skate.', 'KneeGuard', 24.90, 70),
    ('Cotoveleira para Skate', 'Cotoveleira resistente e confortável para proteção durante as manobras de skate.', 'ElbowGuard', 24.90, 200),
    ('Tênis para Skate', 'Tênis especialmente desenvolvido para a prática de skate, garantindo aderência e durabilidade.', 'SkateFoot', 79.90, 200),
    ('Bermuda para Skate', 'Bermuda confortável e resistente para a prática de skate, oferecendo liberdade de movimentos.', 'SkateShorts', 34.90, 250),
    ('Camiseta de Skate', 'Camiseta estilosa e confortável para a prática de skate, com estampas e designs exclusivos.', 'SkateStyle', 24.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (50, 591),
    (50, 592),
    (50, 593),
    (50, 594),
    (50, 595),
    (50, 596),
    (50, 597),
    (50, 598),
    (50, 599),
    (50, 600);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Tapete de Yoga', 'Tapete de yoga antiderrapante e confortável, proporcionando estabilidade e amortecimento.', 'YogaMat', 79.90, 50),
    ('Bolster para Yoga', 'Bolster de apoio para yoga, auxiliando na execução de posturas e no relaxamento.', 'YogaBolster', 39.90, 30),
    ('Bloco de Yoga', 'Bloco de yoga em espuma leve e durável, utilizado para apoio e correção de posturas.', 'YogaBlock', 29.90, 40),
    ('Cinto de Alongamento', 'Cinto de alongamento para yoga, auxiliando na execução de posturas mais avançadas.', 'StretchPro', 24.90, 80),
    ('Roupas para Yoga', 'Conjunto de roupas confortáveis e flexíveis para a prática de yoga.', 'YogaWear', 49.90, 50),
    ('Kit Acessórios para Yoga', 'Kit completo de acessórios para yoga, incluindo tapete, bolster, bloco e cinto.', 'YogaEssentials', 229.90, 70),
    ('Livro de Yoga', 'Livro com guias e práticas de yoga, auxiliando na compreensão e aprimoramento da técnica.', 'YogaGuide', 29.90, 200),
    ('DVD de Yoga', 'DVD com aulas e práticas de yoga, permitindo a prática em casa com instruções profissionais.', 'YogaFlow', 29.90, 250),
    ('Incenso Relaxante', 'Incenso com aroma relaxante para auxiliar na meditação e no ambiente de prática de yoga.', 'YogaScent', 9.90, 200),
    ('Meditação Guiada em Áudio', 'Áudio de meditação guiada para auxiliar no relaxamento e concentração durante o yoga.', 'YogaMeditate', 22.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (51, 601),
    (51, 602),
    (51, 603),
    (51, 604),
    (51, 605),
    (51, 606),
    (51, 607),
    (51, 608),
    (51, 609),
    (51, 610);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Bola de Pilates', 'Bola de pilates para exercícios de fortalecimento, equilíbrio e alongamento.', 'PilateBall', 39.90, 50),
    ('Faixa Elástica de Resistência', 'Faixa elástica de resistência para exercícios de pilates, proporcionando maior desafio muscular.', 'PilateBand', 29.90, 30),
    ('Aparelho de Pilates Reformer', 'Aparelho de pilates reformer para a prática de exercícios de resistência e flexibilidade.', 'PilateReformer', 699.90, 40),
    ('Rolo de Espuma para Pilates', 'Rolo de espuma utilizado para exercícios de fortalecimento, equilíbrio e massagem.', 'PilateRoll', 29.90, 80),
    ('Meia para Pilates', 'Meia antiderrapante para a prática de pilates, proporcionando segurança e estabilidade.', 'GripSocks', 24.90, 50),
    ('Livro de Pilates', 'Livro com guias e práticas de pilates, auxiliando na compreensão e aprimoramento da técnica.', 'PilateGuide', 29.90, 70),
    ('DVD de Pilates', 'DVD com aulas e práticas de pilates, permitindo a prática em casa com instruções profissionais.', 'PilateFlow', 29.90, 200),
    ('Tapete de Pilates', 'Tapete de pilates confortável e antiderrapante, proporcionando conforto durante os exercícios.', 'PilateMat', 49.90, 200),
    ('Acessórios para Pilates', 'Kit completo de acessórios para pilates, incluindo bola, faixa elástica, rolo e meia.', 'PilateEssentials', 229.90, 250),
    ('Cinto de Alongamento para Pilates', 'Cinto de alongamento para pilates, auxiliando na execução de exercícios de flexibilidade.', 'StretchPro', 24.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (52, 611),
    (52, 612),
    (52, 613),
    (52, 614),
    (52, 615),
    (52, 616),
    (52, 617),
    (52, 618),
    (52, 619),
    (52, 620);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Almofada de Meditação', 'Almofada confortável para prática de meditação, proporcionando suporte e conforto durante a sessão.', 'MeditateCushion', 59.90, 200),
    ('Tapete de Meditação', 'Tapete de meditação antiderrapante e macio, criando um espaço confortável para a prática de meditação.', 'MeditateMat', 79.90, 80),
    ('Velas de Aromaterapia', 'Conjunto de velas de aromaterapia para criar uma atmosfera relaxante e calma durante a meditação.', 'AromaCandle', 24.90, 250),
    ('Óleos Essenciais', 'Kit com diferentes óleos essenciais para uso durante a meditação, proporcionando bem-estar e tranquilidade.', 'EssentialOils', 39.90, 200),
    ('Sino de Meditação', 'Sino de meditação em bronze para marcar o início e o fim das sessões de meditação.', 'MeditationBell', 29.90, 50),
    ('CD de Meditação', 'CD com músicas e sons relaxantes para auxiliar na meditação e no relaxamento profundo.', 'MeditationSounds', 29.90, 200),
    ('Livro de Meditação', 'Livro com guias e técnicas de meditação, auxiliando na compreensão e prática da meditação.', 'MeditationGuide', 29.90, 70),
    ('Tapete para Meditação ao Ar Livre', 'Tapete resistente para meditação ao ar livre, proporcionando um espaço confortável em ambientes externos.', 'OutdoorMeditateMat', 49.90, 80),
    ('Banco de Meditação', 'Banco ergonômico para meditação, proporcionando suporte para a postura correta durante a prática.', 'MeditationBench', 69.90, 50),
    ('Máscara para Meditação', 'Máscara confortável para meditação, bloqueando a luz e criando um ambiente tranquilo para a prática.', 'MeditationMask', 24.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (53, 621),
    (53, 622),
    (53, 623),
    (53, 624),
    (53, 625),
    (53, 626),
    (53, 627),
    (53, 628),
    (53, 629),
    (53, 630);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Lisos', 'Shampoo específico para cabelos lisos, proporcionando limpeza e redução de frizz.', 'SmoothShampoo', 24.90, 200),
    ('Condicionador para Cabelos Lisos', 'Condicionador hidratante para cabelos lisos, promovendo maciez e brilho.', 'SmoothConditioner', 24.90, 280),
    ('Creme Alisante', 'Creme alisante para cabelos lisos, proporcionando um efeito liso duradouro.', 'StraighteningCream', 39.90, 250),
    ('Óleo Finalizador para Cabelos Lisos', 'Óleo finalizador para cabelos lisos, controlando o frizz e dando brilho aos fios.', 'SmoothFinishingOil', 29.90, 250),
    ('Máscara de Hidratação para Cabelos Lisos', 'Máscara de hidratação intensa para cabelos lisos, revitalizando os fios.', 'SmoothHydrationMask', 29.90, 220),
    ('Spray Protetor Térmico para Cabelos Lisos', 'Spray protetor térmico para cabelos lisos, protegendo os fios do calor do secador e da chapinha.', 'SmoothHeatProtector', 27.90, 200),
    ('Serum Anti-Frizz para Cabelos Lisos', 'Serum anti-frizz para cabelos lisos, controlando os fios rebeldes e deixando-os mais disciplinados.', 'SmoothFrizzSerum', 24.90, 280),
    ('Escova Modeladora para Cabelos Lisos', 'Escova modeladora para cabelos lisos, facilitando a criação de penteados.', 'SmoothStylingBrush', 22.90, 300),
    ('Mousse para Cabelos Lisos', 'Mousse modelador para cabelos lisos, proporcionando volume e fixação aos fios.', 'SmoothMousse', 26.90, 250),
    ('Pomada Modeladora para Cabelos Lisos', 'Pomada modeladora para cabelos lisos, estilizando os fios e garantindo fixação.', 'SmoothStylingPomade', 24.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (54, 631),
    (54, 632),
    (54, 633),
    (54, 634),
    (54, 635),
    (54, 636),
    (54, 637),
    (54, 638),
    (54, 639),
    (54, 640);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Tingidos', 'Shampoo específico para cabelos tingidos, preservando a cor e proporcionando brilho.', 'ColorProtectShampoo', 24.90, 200),
    ('Condicionador para Cabelos Tingidos', 'Condicionador hidratante para cabelos tingidos, promovendo maciez e proteção da cor.', 'ColorProtectConditioner', 24.90, 280),
    ('Máscara de Hidratação para Cabelos Tingidos', 'Máscara de hidratação intensa para cabelos tingidos, revitalizando os fios e prolongando a cor.', 'ColorProtectHydrationMask', 29.90, 250),
    ('Spray Protetor Térmico para Cabelos Tingidos', 'Spray protetor térmico para cabelos tingidos, protegendo os fios do calor e dos danos externos.', 'ColorProtectHeatProtector', 27.90, 250),
    ('Óleo Finalizador para Cabelos Tingidos', 'Óleo finalizador para cabelos tingidos, proporcionando brilho e proteção da cor.', 'ColorProtectFinishingOil', 29.90, 200),
    ('Shampoo Desamarelador', 'Shampoo desamarelador para cabelos tingidos, neutralizando tons amarelados e realçando a cor.', 'PurpleShampoo', 24.90, 280),
    ('Condicionador Desamarelador', 'Condicionador desamarelador para cabelos tingidos, hidratando os fios e neutralizando tons amarelados.', 'PurpleConditioner', 24.90, 200),
    ('Mousse para Cabelos Tingidos', 'Mousse modelador para cabelos tingidos, proporcionando volume e fixação aos fios.', 'ColorProtectMousse', 26.90, 250),
    ('Spray Fixador para Cabelos Tingidos', 'Spray fixador para cabelos tingidos, garantindo fixação dos penteados e proteção da cor.', 'ColorProtectHairspray', 24.90, 200),
    ('Sérum para Pontas Duplas', 'Sérum para pontas duplas em cabelos tingidos, reparando as pontas danificadas e prolongando a cor.', 'SplitEndSerum', 29.90, 250);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (55, 641),
    (55, 642),
    (55, 643),
    (55, 644),
    (55, 645),
    (55, 646),
    (55, 647),
    (55, 648),
    (55, 649),
    (55, 650);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Grisalhos', 'Shampoo especial para cabelos grisalhos, realçando o brilho prateado dos fios.', 'SilverShampoo', 24.90, 200),
    ('Condicionador para Cabelos Grisalhos', 'Condicionador hidratante para cabelos grisalhos, proporcionando maciez e maleabilidade.', 'SilverConditioner', 24.90, 280),
    ('Tônico Capilar para Cabelos Grisalhos', 'Tônico capilar para cabelos grisalhos, fortalecendo os fios e prevenindo a queda.', 'SilverHairTonic', 29.90, 250),
    ('Gel para Penteados em Cabelos Grisalhos', 'Gel modelador para penteados em cabelos grisalhos, proporcionando fixação e estilo.', 'SilverStylingGel', 24.90, 250),
    ('Óleo Finalizador para Cabelos Grisalhos', 'Óleo finalizador para cabelos grisalhos, controlando o frizz e realçando o brilho prateado.', 'SilverFinishingOil', 29.90, 200),
    ('Máscara de Hidratação para Cabelos Grisalhos', 'Máscara de hidratação profunda para cabelos grisalhos, proporcionando nutrição e vitalidade aos fios.', 'SilverHydrationMask', 29.90, 220),
    ('Pomada Modeladora para Cabelos Grisalhos', 'Pomada modeladora para cabelos grisalhos, estilizando os fios e proporcionando fixação duradoura.', 'SilverStylingPomade', 24.90, 200),
    ('Spray Fixador para Cabelos Grisalhos', 'Spray fixador para cabelos grisalhos, garantindo fixação dos penteados e brilho prateado.', 'SilverHairspray', 27.90, 280),
    ('Cera Modeladora para Cabelos Grisalhos', 'Cera modeladora para cabelos grisalhos, conferindo textura e definição aos fios.', 'SilverStylingWax', 26.90, 250),
    ('Shampoo Seco para Cabelos Grisalhos', 'Shampoo seco para cabelos grisalhos, absorvendo a oleosidade e revitalizando os fios.', 'SilverDryShampoo', 29.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (56, 651),
    (56, 652),
    (56, 653),
    (56, 654),
    (56, 655),
    (56, 656),
    (56, 657),
    (56, 658),
    (56, 659),
    (56, 660);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Cacheados', 'Shampoo específico para cabelos cacheados, limpando suavemente os fios e definindo os cachos.', 'CurlShampoo', 24.90, 200),
    ('Condicionador para Cabelos Cacheados', 'Condicionador hidratante para cabelos cacheados, desembaraçando os fios e proporcionando maciez.', 'CurlConditioner', 24.90, 280),
    ('Creme para Pentear em Cabelos Cacheados', 'Creme para pentear em cabelos cacheados, definindo os cachos e controlando o volume.', 'CurlStylingCream', 29.90, 250),
    ('Gelatina Modeladora para Cabelos Cacheados', 'Gelatina modeladora para cabelos cacheados, proporcionando definição e fixação aos cachos.', 'CurlStylingGelatin', 27.90, 250),
    ('Máscara de Hidratação para Cabelos Cacheados', 'Máscara de hidratação intensa para cabelos cacheados, nutrindo e revitalizando os cachos.', 'CurlHydrationMask', 29.90, 250),
    ('Óleo Finalizador para Cabelos Cacheados', 'Óleo finalizador para cabelos cacheados, proporcionando brilho, controle do frizz e definição dos cachos.', 'CurlFinishingOil', 29.90, 200),
    ('Ativador de Cachos', 'Ativador de cachos para cabelos cacheados, definindo os cachos e conferindo volume.', 'CurlActivator', 26.90, 250),
    ('Leave-in para Cabelos Cacheados', 'Leave-in para cabelos cacheados, protegendo os fios e facilitando a finalização dos cachos.', 'CurlLeaveIn', 24.90, 200),
    ('Spray Umidificador para Cabelos Cacheados', 'Spray umidificador para cabelos cacheados, revitalizando os cachos e controlando o frizz.', 'CurlMist', 29.90, 280),
    ('Shampoo Low Poo para Cabelos Cacheados', 'Shampoo low poo para cabelos cacheados, promovendo uma limpeza suave e preservando a hidratação natural dos fios.', 'CurlLowPooShampoo', 24.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (57, 661),
    (57, 662),
    (57, 663),
    (57, 664),
    (57, 665),
    (57, 666),
    (57, 667),
    (57, 668),
    (57, 669),
    (57, 670);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Camisa Social Masculina', 'Camisa social masculina de algodão com corte clássico, ideal para ocasiões formais.', 'FashionMen', 89.90, 200),
    ('Calça Jeans Masculina', 'Calça jeans masculina com lavagem moderna e modelagem slim, perfeita para looks casuais.', 'DenimCo', 209.90, 80),
    ('Blazer Masculino', 'Blazer masculino de tecido estruturado, ótimo para compor um visual elegante.', 'StyleMasters', 299.90, 50),
    ('Tênis Casual Masculino', 'Tênis casual masculino com design moderno e confortável para uso diário.', 'UrbanSteps', 229.90, 220),
    ('Bermuda de Praia Masculina', 'Bermuda de praia masculina estampada, perfeita para aproveitar o verão com estilo.', 'BeachVibes', 59.90, 250),
    ('Camiseta Básica Masculina', 'Camiseta básica masculina de algodão, ideal para looks despojados.', 'EssentialWear', 29.90, 200),
    ('Jaqueta de Couro Masculina', 'Jaqueta de couro masculina com design clássico, ideal para dias mais frios.', 'LeatherCraft', 249.90, 70),
    ('Moletom com Capuz Masculino', 'Moletom com capuz masculino, perfeito para dias descontraídos e confortáveis.', 'CozyComfort', 79.90, 200),
    ('Camisa Polo Masculina', 'Camisa polo masculina de algodão com detalhes em contraste, ideal para um visual esportivo.', 'SportStyle', 69.90, 220),
    ('Sapato Social Masculino', 'Sapato social masculino de couro com design elegante, ótimo para ocasiões formais.', 'ClassicSteps', 279.90, 60);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (58, 671),
    (58, 672),
    (58, 673),
    (58, 674),
    (58, 675),
    (58, 676),
    (58, 677),
    (58, 678),
    (58, 679),
    (58, 680);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Óleo de Coco Orgânico', 'Óleo de coco orgânico extra virgem, ideal para uso culinário e cuidados com a pele e cabelos.', 'PureNature', 39.90, 200),
    ('Chá Verde em Sachês', 'Chá verde em sachês 100% natural, rico em antioxidantes e propriedades benéficas para a saúde.', 'GreenTeaDelight', 29.90, 280),
    ('Mel Puro', 'Mel puro e natural, produzido de forma sustentável e com alto valor nutricional.', 'SweetHarvest', 29.90, 250),
    ('Barra de Cereal Vegana', 'Barra de cereal vegana com ingredientes naturais, nutritiva e saborosa para lanches rápidos.', 'NatureBite', 9.90, 250),
    ('Suplemento de Vitamina C', 'Suplemento de vitamina C natural em cápsulas, auxilia na imunidade e bem-estar geral.', 'PureVitality', 29.90, 200),
    ('Manteiga de Amendoim Integral', 'Manteiga de amendoim integral sem adição de açúcares, fonte de proteínas e gorduras saudáveis.', 'NuttyDelights', 24.90, 220),
    ('Shampoo Natural', 'Shampoo natural e vegano, livre de sulfatos e parabenos, para cabelos saudáveis e brilhantes.', 'PureHairCare', 24.90, 200),
    ('Condicionador Natural', 'Condicionador natural e vegano, com ingredientes suaves que hidratam e desembaraçam os fios.', 'PureHairCare', 24.90, 280),
    ('Sabonete Artesanal', 'Sabonete artesanal 100% natural, com fragrâncias suaves e ingredientes que cuidam da pele.', 'NaturalEssence', 22.90, 250),
    ('Loção Hidratante Corporal Natural', 'Loção hidratante corporal natural, com ingredientes naturais que nutrem e suavizam a pele.', 'PureSkinCare', 29.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (59, 681),
    (59, 682),
    (59, 683),
    (59, 684),
    (59, 685),
    (59, 686),
    (59, 687),
    (59, 688),
    (59, 689),
    (59, 690);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Barraca para 4 Pessoas', 'Barraca espaçosa para acomodar confortavelmente até 4 pessoas em acampamentos.', 'OutdoorGear', 299.90, 30),
    ('Saco de Dormir Ultraleve', 'Saco de dormir compacto e ultraleve, ideal para trilhas e aventuras ao ar livre.', 'AdventureSleep', 259.90, 50),
    ('Lanterna Recarregável', 'Lanterna recarregável com LED de alta potência, resistente à água e com longa duração de bateria.', 'EcoLight', 49.90, 200),
    ('Colchonete Inflável', 'Colchonete inflável para maior conforto durante o sono em acampamentos e atividades ao ar livre.', 'CampingComfort', 79.90, 80),
    ('Fogareiro Portátil', 'Fogareiro portátil compacto para preparar refeições quentes durante acampamentos e aventuras.', 'CampChef', 89.90, 60),
    ('Cadeira Dobrável', 'Cadeira dobrável leve e resistente, ideal para descanso e momentos de lazer em acampamentos.', 'OutdoorRelax', 49.90, 220),
    ('Kit de Talheres para Camping', 'Kit de talheres compacto para camping, resistente e fácil de transportar em mochilas.', 'CampingEssentials', 29.90, 200),
    ('Garrafa Térmica', 'Garrafa térmica com capacidade para manter líquidos quentes ou frios por longos períodos.', 'ThermalGear', 39.90, 250),
    ('Rede de Descanso', 'Rede de descanso confortável e resistente, ideal para relaxar e aproveitar momentos ao ar livre.', 'HammockLife', 59.90, 200),
    ('Kit de Panelas para Camping', 'Kit de panelas compacto e leve para preparar refeições durante acampamentos e atividades ao ar livre.', 'CampCookware', 99.90, 70);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (60, 691),
    (60, 692),
    (60, 693),
    (60, 694),
    (60, 695),
    (60, 696),
    (60, 697),
    (60, 698),
    (60, 699),
    (60, 700);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Carrinho de Bebê', 'Carrinho de bebê resistente e confortável, com diversas posições de reclínio e fácil de manusear.', 'BabyWheels', 599.90, 20),
    ('Cadeira de Alimentação', 'Cadeira de alimentação segura e prática, com ajuste de altura e bandeja removível.', 'MealTime', 299.90, 30),
    ('Berço Portátil', 'Berço portátil dobrável, ideal para viagens e passeios, com colchonete e mosquiteiro incluso.', 'TravelNest', 299.90, 25),
    ('Banheira para Bebê', 'Banheira ergonômica e segura para o banho do bebê, com suporte e fácil de esvaziar.', 'BabyBath', 229.90, 40),
    ('Cadeirinha de Carro', 'Cadeirinha de carro confortável e segura, com cinto de segurança ajustável e proteção lateral.', 'SafeRide', 349.90, 25),
    ('Babá Eletrônica', 'Babá eletrônica com áudio e vídeo, permite monitorar o bebê a distância com qualidade e segurança.', 'BabyMonitor', 279.90, 50),
    ('Trocador Portátil', 'Trocador portátil compacto e prático, ideal para trocar fraldas em qualquer lugar.', 'EasyChange', 49.90, 80),
    ('Andador para Bebê', 'Andador para bebê com altura ajustável, brinquedos interativos e apoio seguro para os primeiros passos.', 'Walk n Play', 249.90, 35),
    ('Cadeirinha de Balanço', 'Cadeirinha de balanço com movimento suave e diversas posições, ideal para relaxar e acalmar o bebê.', 'BabyRelax', 279.90, 30),
    ('Tapete de Atividades', 'Tapete de atividades macio e colorido, com brinquedos pendurados para estimular o desenvolvimento do bebê.', 'PlayTime', 99.90, 60);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (61, 701),
    (61, 702),
    (61, 703),
    (61, 704),
    (61, 705),
    (61, 706),
    (61, 707),
    (61, 708),
    (61, 709),
    (61, 710);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Bolo de Aniversário', 'Bolo de aniversário decorado e personalizado, com diversos sabores e tamanhos disponíveis.', 'SweetCelebration', 99.90, 20),
    ('Balões Coloridos', 'Pacote com balões coloridos em diversos tamanhos, perfeitos para decorar festas e eventos.', 'PartyTime', 9.90, 200),
    ('Decoração de Mesa', 'Kit de decoração de mesa para festas, incluindo toalha, pratos, copos, talheres e guardanapos.', 'PartyDecor', 49.90, 50),
    ('Convites Personalizados', 'Pacote com convites personalizados para festas, com diversos temas e estilos disponíveis.', 'InviteDesign', 29.90, 30),
    ('Velas Decorativas', 'Conjunto com velas decorativas para bolos de aniversário, com diversos formatos e cores.', 'CandleMagic', 24.90, 80),
    ('Chapéus de Festa', 'Pacote com chapéus de festa coloridos e divertidos, ideais para animar qualquer comemoração.', 'PartyHats', 9.90, 250),
    ('Kit de Lembrancinhas', 'Kit com lembrancinhas personalizadas para festas, incluindo sacolinhas, adesivos e brindes.', 'PartyFavors', 29.90, 40),
    ('Painel de Fundo para Fotos', 'Painel de fundo decorativo para tirar fotos em festas e eventos, com diversos temas disponíveis.', 'PhotoBooth', 79.90, 20),
    ('Cobertura de Mesa', 'Cobertura de mesa decorativa para festas, disponível em diferentes cores e estampas.', 'TableCover', 29.90, 60),
    ('Descartáveis para Festa', 'Pacote com pratos, copos, talheres e guardanapos descartáveis para festas e eventos.', 'PartyEssentials', 29.90, 200);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (62, 711),
    (62, 712),
    (62, 713),
    (62, 714),
    (62, 715),
    (62, 716),
    (62, 717),
    (62, 718),
    (62, 719),
    (62, 720);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Action Figure - Personagem X', 'Action figure detalhado do personagem X, com articulações e acessórios inclusos.', 'CollectibleHeroes', 299.90, 5),
    ('Cartas Colecionáveis - Edição Especial', 'Pacote com cartas colecionáveis da edição especial, incluindo cartas raras e holográficas.', 'CollectorCards', 49.90, 20),
    ('Miniaturas de Carros Antigos', 'Miniaturas de carros antigos colecionáveis em escala reduzida, com detalhes realistas.', 'VintageWheels', 79.90, 25),
    ('Boneco de Pelúcia - Personagem Y', 'Boneco de pelúcia do personagem Y, macio e fofinho, perfeito para colecionadores.', 'PlushToys', 59.90, 30),
    ('Figurinha Autografada - Time de Futebol', 'Figurinha autografada por jogador famoso do time de futebol, em perfeito estado de conservação.', 'SoccerCollectibles', 299.90, 3),
    ('Moedas Antigas - Coleção Completa', 'Coleção completa de moedas antigas de diferentes países e épocas, em excelente estado.', 'NumismaticTreasures', 499.90, 3),
    ('Bonecas de Porcelana - Edição Limitada', 'Bonecas de porcelana colecionáveis em edição limitada, com trajes e detalhes delicados.', 'PorcelainDolls', 249.90, 20),
    ('Miniaturas de Aviões de Guerra', 'Miniaturas de aviões de guerra colecionáveis em escala reduzida, com pintura e detalhes autênticos.', 'Warbirds', 89.90, 22),
    ('Revista Rara - Edição Especial', 'Revista rara e colecionável da edição especial, com matérias exclusivas e capa personalizada.', 'CollectorsMagazine', 39.90, 25),
    ('Estátua de Personagem - Tamanho Real', 'Estátua em tamanho real do personagem, produzida em resina de alta qualidade e pintada à mão.', 'HeroicStatues', 999.90, 2);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (63, 721),
    (63, 722),
    (63, 723),
    (63, 724),
    (63, 725),
    (63, 726),
    (63, 727),
    (63, 728),
    (63, 729),
    (63, 730);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Kit de Pincéis', 'Kit de pincéis para pintura em diferentes tamanhos e formatos, ideais para artesanato e belas artes.', 'ArtBrush', 29.90, 50),
    ('Tesoura de Precisão', 'Tesoura de precisão com lâminas afiadas e ponta fina, perfeita para trabalhos detalhados em artesanato.', 'CraftCut', 29.90, 80),
    ('Cola para Artesanato', 'Cola transparente e resistente para diversos tipos de materiais usados em artesanato.', 'CraftBond', 9.90, 200),
    ('Fitas Decorativas', 'Pacote com fitas decorativas em diferentes cores e estampas, ideais para enfeitar projetos de artesanato.', 'CraftRibbons', 24.90, 70),
    ('Tintas Acrílicas', 'Tintas acrílicas de alta qualidade em diversas cores, perfeitas para pintura em telas e trabalhos artísticos.', 'ArtColors', 24.90, 40),
    ('Miçangas e Contas', 'Pacote com miçangas e contas coloridas em diferentes formatos, ideais para criar bijuterias e artesanato em geral.', 'BeadWorld', 22.90, 220),
    ('Papel Decorativo', 'Pacote com papel decorativo em diferentes estampas e texturas, perfeito para scrapbook e outros projetos de papelaria.', 'CraftPaper', 9.90, 200),
    ('Carimbo Decorativo', 'Carimbo decorativo com diferentes desenhos e padrões, ideal para personalizar projetos de artesanato.', 'StampIt', 7.90, 250),
    ('Kit de Agulhas para Costura', 'Kit de agulhas para costura em diferentes tamanhos, perfeito para trabalhos de costura e artesanato têxtil.', 'SewCraft', 24.90, 90),
    ('Lantejoulas e Paetês', 'Pacote com lantejoulas e paetês em diversas cores e formatos, ideais para projetos de customização e artesanato.', 'Sequins', 6.90, 280);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (64, 731),
    (64, 732),
    (64, 733),
    (64, 734),
    (64, 735),
    (64, 736),
    (64, 737),
    (64, 738),
    (64, 739),
    (64, 740);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Curso de Fotografia Profissional', 'Aprenda as técnicas avançadas de fotografia, desde o uso da câmera até a edição de imagens.', 'PhotoMasters', 299.90, 20),
    ('Treinamento em Marketing Digital', 'Aprenda as estratégias e ferramentas essenciais para criar campanhas eficazes de marketing digital.', 'DigitalSuccess', 299.90, 20),
    ('Curso de Desenvolvimento Web', 'Aprenda a criar sites profissionais e responsivos utilizando as principais linguagens de programação.', 'WebAcademy', 249.90, 25),
    ('Treinamento em Gestão de Projetos', 'Aprenda as melhores práticas de gestão de projetos e conquiste resultados eficientes.', 'ProjectPro', 299.90, 22),
    ('Curso de Design Gráfico', 'Aprenda a criar designs gráficos atraentes e profissionais utilizando as principais ferramentas do mercado.', 'DesignMaster', 249.90, 28),
    ('Treinamento em Liderança', 'Desenvolva suas habilidades de liderança e conquiste resultados excepcionais em sua carreira.', 'LeadershipNow', 299.90, 20),
    ('Curso de Idiomas - Inglês', 'Aprenda o idioma inglês de forma prática e eficiente, com aulas interativas e conteúdo atualizado.', 'LanguageInstitute', 299.90, 25),
    ('Treinamento em Vendas', 'Aprenda as técnicas e estratégias de vendas de sucesso para impulsionar seu negócio.', 'SalesMastery', 249.90, 25),
    ('Curso de Programação em Python', 'Aprenda a programar em Python, uma das linguagens mais populares e versáteis da atualidade.', 'PythonAcademy', 249.90, 20),
    ('Treinamento em Comunicação Eficaz', 'Desenvolva suas habilidades de comunicação e seja assertivo em suas interações pessoais e profissionais.', 'EffectiveComm', 249.90, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (65, 741),
    (65, 742),
    (65, 743),
    (65, 744),
    (65, 745),
    (65, 746),
    (65, 747),
    (65, 748),
    (65, 749),
    (65, 750);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Shampoo para Cabelos Cacheados', 'Shampoo especialmente formulado para limpar e hidratar os cabelos cacheados, proporcionando definição e maciez.', 'CurlyHair', 29.90, 50),
    ('Condicionador para Cabelos Cacheados', 'Condicionador que desembaraça e nutre os cabelos cacheados, deixando-os mais brilhantes e fáceis de pentear.', 'CurlyHair', 29.90, 50),
    ('Creme de Pentear para Cabelos Cacheados', 'Creme de pentear que define os cachos, reduz o frizz e proporciona mais volume e movimento aos cabelos cacheados.', 'CurlyHair', 24.90, 50),
    ('Gel para Cabelos Cacheados', 'Gel modelador que fixa os cachos e controla o volume dos cabelos cacheados, deixando-os com aspecto natural e definido.', 'CurlyHair', 29.90, 50),
    ('Máscara de Hidratação para Cabelos Cacheados', 'Máscara de tratamento intensivo que hidrata profundamente os cabelos cacheados, devolvendo a vitalidade e o brilho.', 'CurlyHair', 39.90, 50),
    ('Óleo Finalizador para Cabelos Cacheados', 'Óleo finalizador que controla o frizz e proporciona brilho e maciez aos cabelos cacheados, sem deixar resíduos.', 'CurlyHair', 24.90, 50),
    ('Ativador de Cachos para Cabelos Cacheados', 'Ativador de cachos que define e revitaliza os cabelos cacheados, deixando-os com aspecto natural e sem pesar.', 'CurlyHair', 24.90, 50),
    ('Leave-in para Cabelos Cacheados', 'Leave-in que hidrata, protege e facilita a finalização dos cabelos cacheados, proporcionando controle e definição dos cachos.', 'CurlyHair', 24.90, 50),
    ('Spray Umidificador para Cabelos Cacheados', 'Spray umidificador que revitaliza e reativa os cachos dos cabelos cacheados, mantendo-os hidratados e definidos ao longo do dia.', 'CurlyHair', 29.90, 50),
    ('Creme Noturno para Cabelos Cacheados', 'Creme noturno que nutre e restaura os cabelos cacheados enquanto você dorme, proporcionando cachos mais definidos e saudáveis.', 'CurlyHair', 29.90, 50);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (66, 751),
    (66, 752),
    (66, 753),
    (66, 754),
    (66, 755),
    (66, 756),
    (66, 757),
    (66, 758),
    (66, 759),
    (66, 760);

INSERT INTO Products (Name, Description, Brand, Price, Stock)
VALUES
    ('Vestido Plus Size Estampado', 'Vestido estampado plus size com modelagem soltinha e tecido leve, perfeito para looks descontraídos e confortáveis.', 'FashionCurve', 89.90, 30),
    ('Blusa Plus Size Básica', 'Blusa básica plus size confeccionada em malha de algodão, ideal para compor diversos looks casuais.', 'FashionCurve', 49.90, 50),
    ('Calça Jeans Plus Size', 'Calça jeans plus size com cintura alta e modelagem que valoriza as curvas, garantindo conforto e estilo.', 'FashionCurve', 99.90, 20),
    ('Saia Midi Plus Size', 'Saia midi plus size em tecido leve e fluido, com estampa floral e cintura elástica para ajuste perfeito.', 'FashionCurve', 79.90, 25),
    ('Camisa Social Plus Size', 'Camisa social plus size confeccionada em tecido de algodão, perfeita para compor looks elegantes e sofisticados.', 'FashionCurve', 69.90, 25),
    ('Vestido de Festa Plus Size', 'Vestido de festa plus size com detalhes em renda, modelagem acinturada e tecido de alta qualidade, ideal para ocasiões especiais.', 'FashionCurve', 249.90, 20),
    ('Blazer Plus Size', 'Blazer plus size confeccionado em tecido de alfaiataria, com corte impecável e caimento perfeito, ideal para looks formais.', 'FashionCurve', 219.90, 8),
    ('Vestido Longo Plus Size', 'Vestido longo plus size com estampa exclusiva, decote em V e fenda lateral, perfeito para ocasiões especiais e festas.', 'FashionCurve', 229.90, 22),
    ('Camiseta Plus Size Estampada', 'Camiseta estampada plus size confeccionada em malha de algodão, ideal para compor looks despojados e confortáveis.', 'FashionCurve', 39.90, 50),
    ('Macacão Plus Size', 'Macacão plus size em tecido de viscose, com modelagem pantacourt e detalhe de amarração na cintura, garantindo estilo e conforto.', 'FashionCurve', 209.90, 20);

INSERT INTO CategoryProducts (CategoryId, ProductId)
VALUES
    (67, 761),
    (67, 762),
    (67, 763),
    (67, 764),
    (67, 765),
    (67, 766),
    (67, 767),
    (67, 768),
    (67, 769),
    (67, 770);
