# challengeAbm
challenge-Tecnico


ABM de "Usuario"

Base de datos con SQL-Server   

modelo:     Usuario

      IdUsuario 
      
      UserName (obligatorio)
      
      Nombre (obligatorio)
      
      Email ( obligatorio)
      
      Telefono
      
Se utilizó:

    .Net 6
    Asp.Net (mvc)
    ORM Entity Framework Core
    Bootstrap 5
    
    
Proyecto diseñado en capas:

    1 - Data
      
    2 - Logic
      
    3 - Shared
      
    4 - App Front-end (mvc) 
      
      
Se utiliza Patron  Unit Of Work y Repository

  implementacion de capa de abstraccion con unit of work, tambien se utilizo un repositorio generico 
  con los metodos standards y un repositorio propio de Usuarios 
  
