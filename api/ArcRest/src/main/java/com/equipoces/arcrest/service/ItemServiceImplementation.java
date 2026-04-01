package com.equipoces.arcrest.service;

import com.equipoces.arcrest.model.Item;
import com.equipoces.arcrest.repository.ItemRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ItemServiceImplementation implements ItemService {
    @Autowired
    private ItemRepository itemRepository;

    @Override
    public List<Item> getAllItems() {
        return (List<Item>) itemRepository.findAll();
    }

    @Override
    public Optional<Item> getItemById(int id) {
        return itemRepository.findById(id);
    }

    @Override
    public Item createItem(Item character) {
        return itemRepository.save(character);
    }
}
