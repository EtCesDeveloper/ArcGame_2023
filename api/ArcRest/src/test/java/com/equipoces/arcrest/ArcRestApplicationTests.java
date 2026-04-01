package com.equipoces.arcrest;

import com.equipoces.arcrest.model.Character;
import com.equipoces.arcrest.repository.CharacterRepository;
import com.equipoces.arcrest.service.CharacterService;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.Optional;

@SpringBootTest
class ArcRestApplicationTests {
    Character character = new Character("Arc", "Un mago magnífico");

    @Autowired
    private CharacterService characterService;

    @Autowired
    private CharacterRepository characterRepository;

    @BeforeEach
    public void initialize() {
        characterService.createCharacter(character);
    }

    @Test
    public void testCheckCharacterCreated() {
        Optional<Character> characterFromDb = characterRepository.findById(character.getId());
        Assertions.assertNotNull(characterFromDb);
    }

    @Test
    public void testFindCharacterById() {
        Optional<Character> characterFromDb = characterRepository.findById(character.getId());
        int newCharacterId = characterFromDb.map(Character::getId).orElse(0);

        Assertions.assertEquals(character.getId(), newCharacterId);
    }

    @Test
    public void testCheckCharacterName() {
        Optional<Character> characterFromDb = characterRepository.findById(character.getId());

        String newCharacterName = characterFromDb.map(Character::getName).orElse(null);
        Assertions.assertEquals(character.getName(), newCharacterName);
    }

    @Test
    public void testCheckCharacterDescription() {
        Optional<Character> characterFromDb = characterRepository.findById(character.getId());

        String newCharacterDescription = characterFromDb.map(Character::getDescription).orElse(null);
        Assertions.assertEquals(character.getDescription(), newCharacterDescription);
    }
}
