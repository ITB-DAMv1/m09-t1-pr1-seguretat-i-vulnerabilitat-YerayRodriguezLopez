1.
L'OWASP (Open Web Application Security Project) publica un rànquing de les vulnerabilitats més comunes en aplicacions web. Del Top 10 del 2021, he escollit aquestes tres:

A03:2021 – Injecció (Injection)
Descripció: Es produeix quan dades no verificades són injectades en una consulta SQL, comandes del sistema o altres interpretadors.

Impacte: Un atacant pot obtenir dades sensibles, modificar informació, eliminar bases de dades o executar codi maliciós.

Mesures de protecció:

Utilitzar consultes preparades (Prepared Statements).

Evitar concatenar dades d’entrada directament a consultes SQL.

Implementar ORM com Entity Framework per gestionar la base de dades.

A05:2021 – Configuració de seguretat deficient (Security Misconfiguration)
Descripció: Errors en la configuració del servidor, bases de dades o aplicacions poden deixar vulnerabilitats obertes.

Impacte: Atacs de denegació de servei (DoS), exposició de dades sensibles o execució de codi arbitrari.

Mesures de protecció:

Desactivar serveis i funcionalitats innecessàries.

Assegurar-se que els logs no revelen informació crítica.

Aplicar actualitzacions i patches de seguretat regularment.

A07:2021 – Fallada en la identificació i autenticació (Identification & Authentication Failures)
Descripció: Errors en la gestió d’usuaris, contrasenyes febles o sessions insegures poden permetre a un atacant prendre control d’un compte.

Impacte: Robatori d’identitat, frau i accés no autoritzat.

Mesures de protecció:

Implementar autenticació multifactor (MFA).

Imposar polítiques de contrasenyes segures.

Utilitzar JWT (JSON Web Tokens) o OAuth per gestionar sessions de forma segura.

2.
a) Sentències SQL usades en l'exercici SQL Inseckten
-1
SELECT username 
FROM users 
WHERE username ='jane';--' AND password ='d41d8cd98f00b204e9800998ecf8427e';

-2
SELECT username 
FROM users 
WHERE username =''; drop table users; --' AND password ='d41d8cd98f00b204e9800998ecf8427e';

-3
SELECT username 
FROM users 
WHERE username ='' or true;--' AND password ='d41d8cd98f00b204e9800998ecf8427e';

-4
SELECT username 
FROM users 
WHERE username ='' or true limit 1;--' AND password ='d41d8cd98f00b204e9800998ecf8427e';

-5
SELECT product_id, brand, size, price 
FROM shoes 
WHERE brand=''; select username, password from users;--';

-6
SELECT username 
FROM users 
WHERE username =''; select salary as username from staff where firstname = 'Greta Maria';--' AND password ='d41d8cd98f00b204e9800998ecf8427e';

-7
SELECT product_id, brand, size, price 
FROM shoes 
WHERE brand='' union select name, email, salary, employed_since from staff;--';

b) Protecció contra SQL Injection en Razor Pages i Entity Framework

Utilitzar consultes parametritzades.
Implementar ORM segur com Entity Framework (que evita concatenació de strings).
Validació estricta de les dades d'entrada abans d'executar una consulta.
Evitar SQL dinàmic: No generar consultes SQL amb dades d'entrada sense filtrar.

3.
a) Control d’accés per rols
Rol	Permisos
Client	Comprar obres, deixar ressenyes.
Artista	Publicar obres, modificar les pròpies obres.
Account Manager	Aprovar nous artistes, gestionar verificacions.
Administrador	Accés total, gestió d'usuaris i dades.
b) Política de contrasenyes
Requisits de contrasenya:

Mínim 12 caràcters, almenys una majúscula, un número i un símbol.

Bloqueig després de 5 intents fallits.

Canvi obligatori cada 6 mesos.

Polítiques diferents segons el rol:

Clients: normes estàndard.

Artistes i Account Managers: MFA obligatori.

Administradors: Canvi de contrasenya cada 3 mesos, MFA obligatori.

c) Avaluació de la informació i encriptació
Dades sensibles:

Encriptar: contrasenyes, dades bancàries, DNIs.

No encriptar: noms i descripcions d’obres.

Mètodes d’encriptació:

Contrasenyes: bcrypt.

Dades bancàries: AES-256.

4.
Definició: L’autenticació basada en tokens permet identificar usuaris mitjançant un identificador digital (token) en lloc de sessions tradicionals.

Tipus de tokens:

JWT (JSON Web Tokens) – Comú en APIs REST.

OAuth 2.0 – Permet autenticació a través de serveis externs (Google, Facebook).

SAML (Security Assertion Markup Language) – Usat en entorns empresarials.

Llibreries .NET per implementar tokens:

Microsoft.AspNetCore.Authentication.JwtBearer

IdentityServer4

6. Referències
OWASP Foundation (2021). Top 10 Vulnerabilities. Recuperat de https://owasp.org/Top10/

Microsoft Docs (2024). Security.Cryptography in .NET. Recuperat de https://learn.microsoft.com/

