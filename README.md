# Terminal Notes App (C#)

A terminal-based notes application written in C#, designed for developers who
prefer fast, keyboard-driven workflows and full control over their data.

No UI. No cloud. No infrastructure. Just files and a clean CLI.

---

## Overview

This project is a single-node, pure .NET command-line application that lets you
create, manage, search, and edit notes directly from the terminal.

Notes are stored as plain text or Markdown files on disk, while metadata is
maintained in an index file for fast access.

The goal of this project is not minimalism, but **correctness, clarity, and
clean design**.

---

## Features

- Create notes from the terminal
- Edit notes using your preferred editor
- List notes with metadata
- Tag notes
- Full-text search
- Soft delete with restore support
- File-based storage (human-readable)
- Cross-platform (Windows, macOS, Linux)

---

## Non-Goals

This project intentionally does NOT include:
- GUI or TUI
- Cloud sync
- Databases
- Networking
- Plugins

It is designed to stay focused and understandable.

---

## Storage Layout

Example directory structure:

```
~/notes/
0001.md
0002.md
trash/
index.json
```


- Note content lives in files
- Metadata lives in `index.json`
- Deleted notes are moved to `trash/`

---

## Example Usage

```bash
notes add 001.txt
notes open 001.txt
notes list
notes search await
notes delete 001.txt
notes restore 001.txt
```
