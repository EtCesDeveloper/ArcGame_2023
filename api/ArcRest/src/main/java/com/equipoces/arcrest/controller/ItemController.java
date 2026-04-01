package com.equipoces.arcrest.controller;

import com.equipoces.arcrest.model.Item;
import com.equipoces.arcrest.service.ItemService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/items")
public class ItemController {
    @Autowired
    private ItemService itemService;

    @GetMapping
    public List<Item> getAll() {
        return itemService.getAllItems();
    }

    @GetMapping("/{id}")
    public Optional<Item> findItemById(@PathVariable("id") int id) {
        return itemService.getItemById(id);
    }

    @PostMapping("/create")
    public Item createCharacter(@RequestBody Item item) {
        return itemService.createItem(item);
    }
}
