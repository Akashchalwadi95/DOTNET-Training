const textType = (text) => {
  const trimmedText = text.trim();
  return trimmedText.replace(/[^a-zA-Z]/g, '');
}

export { textType }