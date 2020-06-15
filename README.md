# moneda
Net Core Currency Exchange Sample Api



2a) ¿Qué opina de pasar el id de usuario como input del endpoint? ¿Cómo mejoraría la transacción para asegurarnos de que el usuario que pidió la compra es quien dice ser?

R: No esta mal pasar el userId como input del endpoint, pero para asegurar que la transaccion pertenece al usuario que dice ser hay que implementar un controller que nos autentique y nos regrese un token JWT, en el controller usar el atributo [Authorize] ,en la transaccion de comprar monedas pasar el token y comprobar el usuario.
