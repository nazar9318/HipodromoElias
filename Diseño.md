# Api
- Por simplicidad se eligió desarrollar el sistema con .net core 5, concretamente con ASP.Net Core.
- El dominio está diseñado separando responsabilidades: las clases tienen pocas responsabilidades, el comportamiento esperado por el usuario lo realizan los services y controllers.
- Para cada servicio se desarrollaron tests unitarios, probando funcionalidades y casos borde.
- Se prescindió de base de datos, contando con clases constantes para las mesas, categorías y clientes.
- Dado que no hay base de datos, las reservas se guardan solamente mientras se ejecuta la aplicación, implementando el patrón Singleton para conseguirlo.
- Se implementaron excepciones para casos de fallo de uso de usuario. Ejemplos: querer reservar para fechas de antes del momento de reservar, o pedir mesas con disponibilidad que no existe.
- En caso de que se quiera probar solamente la api, fuera del front, puede optarse por correr la api con swagger

# Front
- Para el front se eligió React, por su accesibilidad y experiencia propia con dicha tecnología.
- Para navegar entre las páginas, además de las acciones con la app, se cuenta con una navbar en la parte superior
- Se usó CSS para los estilos de las páginas y componentes

# Funcionalidades además de las especificadas por el enunciado
- Cada cliente puede elegir la cantidad de personas para su reserva.
- Cada cliente sólo puede reservar a nombre de sí mismo.
- Cada cliente sólo puede eliminar sus propias reservas, ya sea en reservas con fecha o listas de espera.
- Cada cliente puede ver el listado completo de mesas y también ver la ocupación de las mismas para fechas especificadas
- Loggeo
  - Cada usuario se loggea con su nombre como usuario y número de cliente como contraseña.
  - Se puede desloggear en cualquier screen.
  - El sistema guarda el número de cliente para usarlo para las reservas.
- Rol de administrador:
  - El usuario puede loggearse como administrador si conoce las credenciales ("admin" y "0")
  - El administrador puede reservar para cualquier cliente, la única restricción son las categorías
  - El administrador puede eliminar cualquier reserva de cualquier cliente.
  - El administrador puede acceder al listado de clientes, categorías, además del de mesas. Esto se pensó en caso de que en el futuro quieran agregarse (o quitarse) clientes, cateogorías o mesas nuevas.
 
# Funcionalidades descartadas o que quedaron sin desarrollar
- Modificación de reserva: se intentó que las reservas puedan modificarse, por fecha o cantidad de personas, para evitar que el cliente tenga que eliminar la reserva original para luego crear otra. Sin embargo, a nivel uso encontré que no cambiaba mucho el flujo, sólo complicaba la lógica sin facilitarle nada al usuario.
- Eliminación automática de lista de espera: al implementar la lista de espera, se decidió que ésta guardara la fecha de la misma. Pensé que sería muy útil que las listas de espera se borraran en caso de que la fecha de la misma quedara detrás de la fecha actual en que se usara la app. Lamentablemente no me quedó tiempo de probarlo.
- Intenté que en el front hubiera un carrusel de fotos del restaurante, pero se volvió complicado manejar las distintas resoluciones de las imágenes encontradas, por lo que decidí dejarlo de lado para dedicar el tiempo a las demás funcionalidades.

# Autocríticas
- Estilos: los encuentro muy simples y, revisando la página del restaurante, creo que no van mucho con él. Quedaron por una cuestión de tiempos de desarrollo.
- Tests: me hubiera gustado pensar y hacer más tests, si bien creo que los que están cubren todo el flujo, creo que podría haber pensado algunos tests más integrales.
