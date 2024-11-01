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

  # Funcionalidades
  -
