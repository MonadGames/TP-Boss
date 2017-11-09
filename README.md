![Logo Monad Games](monad.jpg)

# The long way home


## Progreso total

### Player

El player actual consiste en un prefab brindado por Unity Store, motivo por el cual tiene apariencia de ninja.

Monad Games esta trabajando en el diseño y desarrollo de un nuevo personaje que contenga propiedades deseadas para el proyecto. Dado que el perfil del mismo es el de un niño de aproximadamente 8 años, es necesario que este sea delgado, con buena movilidad física y apariencia nerviosa y/o temerosa.  

  - #### Movilidad
    El movimiento del personaje esta separado en varias acciones:

      - Saltar: El personaje tiene desde un comienzo la habilidad de saltar, ya sea pequeños saltos (no existe el doble salto) como grandes saltos. Estos últimos son utilizados únicamente cuando el personaje pisa un tipo de suelo especifico. Ambas acciones se activan con la tecla "Space".

      - Caminar y correr: Normalmente el estado de caminar se da cuando un jugador utiliza las teclas de movimiento "Left" y "Right" y combinadas con la tecla "Shift" el personaje pasara del estado caminar a correr.

  - #### Poderes
    Temporalmente solo es posible utilizar dos poderes "Light Spell" y "Dark Spell". Por el momento existen solo algunas diferencias entre ellos:

      - Light Spell: De un color blanco azulado y costo de utilización bastante menor a su contraparte, también posee un poder de ataque reducido.

      - Dark Spell: De un color negro violatado y costo de utilización mucho mayor. Posee un gran poder de ataque.

        Ambos poderes son activados con la tecla "Z".

  - #### Activar Dialogos
    Como dice el titulo, el jugador puede activar el dialogo con un Npc apretando la tecla "E".

### Nivel
  Actualmente solo contamos con la primera mitad del nivel 1, por lo que la sensación de juego es corta y limitada.

  - #### Escenario
    El escenario consiste en pequeñas subidas y bajadas con apariencia de suelo boscoso. Además, algunas partes del mapa contienen escalones que parecen estar levitando y partes de tierra especiales capaces de permitirle al player hacer su gran salto.

  - #### Background
    El background consiste en un bosque, el cual con ayuda de la técnica parallax da la sensación de profundidad en el ambiente de juego.

### Ambientacíon
  Como la mayoría de los items, la ambientación aun esta en estado alpha y sera mejorada conforme pase el desarrollo del proyecto.

  - #### Tormenta
    El ambiente actual dentro del juego es una tortamenta, la cual sigue al personaje todo el tiempo. Esta tormenta esta conformada por una lluvia intensa con su respectivo efecto de sonido, así también por una niebla persistente.

  - #### Musica
    Contamos con un loop de musica lúgubre que brinda la sensación de inseguridad y suspenso al jugador. La musica puede escucharse en este [link](https://www.youtube.com/watch?v=f9gZcuKq4FI).

### Enemigos

  - #### Tipos de enemigos
    Existen dos tipos de enemigos, uno por tierra y uno por aire. Cada uno con su respectivo ataque y defensa. Por el momento un ataque consiste en la colisión misma con el jugador.

  - #### IA
    La "inteligencia artificial" que manejan los Enemy consiste en rondar de izquierda a derecha en un radio de movimiento definido, si en algún momento el player entra en su radio de vision (también definido) el Enemy lo seguirá hasta que este salga de su radio de vision. Una vez el player "escapo" del Enemy, este volverá a su posición inicial para seguir con su estado de guardia.

  - #### Muerte
    La muerte de los Enemy esta en estado alpha, consiste simplemente en hacer desaparecer completamente al enemy sin ningún tipo de animación.

### NPC
  Proveemos solo un tipo de NPC el cual consiste en el fantasma de una niña la cual es nuestra introductora del juego como jugadores. Se encarga de contarnos el contexto del uego y su objetivo. Este NPC provee un icono sobre su cabeza señalando que el jugador puede interactuar seleccionando la tecla "E".

  - #### Dialogos
    Los diálogos consisten en una viñeta a la derecha del NPC, el cual nos muestra el contenido del juego.

### Efectos

  - #### Impacto de poderes
  Como con la animación de los poderes, utilizamos un prefab diseñado por una persona externa al equipo de desarrollo. Logramos recrear el efecto de "Hit" una vez el Spell colisiona con un Enemy.

  - #### Ilusion de sueño
  Utilizando Post processing configuramos una serie de efectos visuales ligados a la cámara. Estos efectos recrean la sensación de sueño dentro del juego y oscureces el entorno para mostrar una imagen mas lúgubre.
